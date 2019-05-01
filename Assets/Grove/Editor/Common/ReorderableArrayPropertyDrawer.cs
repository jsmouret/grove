using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Assertions;

namespace Grove.Common.Editor
{
	[CustomPropertyDrawer(typeof(ReorderableArray), true)]
	[CustomPropertyDrawer(typeof(Containers.List), true)]
	public class ReorderableArrayPropertyDrawer : PropertyDrawer
	{
		private const string ItemsProperty = "m_Items";
		private const float PaddingTop = 2;
		private const float PaddingBottom = 2;
		private const float PaddingLeft = 10;
		private Dictionary<string, ReorderableList> m_Lists = null;
		private ReorderableList m_List;

		private void Init(SerializedProperty property)
		{
			if (m_Lists == null)
			{
				m_Lists = new Dictionary<string, ReorderableList>();
			}

			var key = property.propertyPath;
			if (!m_Lists.TryGetValue(key, out m_List))
			{
				var items = property.FindPropertyRelative(ItemsProperty);
				Assert.IsNotNull(items);

				m_List = new ReorderableList(property.serializedObject, items, true, false, true, true)
				{
					elementHeight = EditorGUIUtility.singleLineHeight + PaddingTop + PaddingBottom,
					headerHeight = PaddingTop,
					onAddCallback = OnAddCallback,
					drawElementCallback = DrawElementCallback,
					elementHeightCallback = ElementHeightCallback,
				};

				m_Lists[key] = m_List;
			}
		}

		private void OnAddCallback(ReorderableList list)
		{
			list.serializedProperty.arraySize += 1;
			list.index = list.serializedProperty.arraySize - 1;

			// Change default behavior to reset the new value instead of copying the last value of the array
			list.serializedProperty.GetArrayElementAtIndex(list.index).ResetValue();
		}

		private void DrawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
		{
			rect.yMin += PaddingTop;
			rect.xMin += PaddingLeft;

			var element = m_List.serializedProperty.GetArrayElementAtIndex(index);
			EditorGUI.PropertyField(rect, element, GUIContent.none, true);
		}

		private float ElementHeightCallback(int index)
		{
			var element = m_List.serializedProperty.GetArrayElementAtIndex(index);
			return EditorGUI.GetPropertyHeight(element, GUIContent.none, true) + PaddingTop + PaddingBottom;
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			Init(property);

			label = EditorGUI.BeginProperty(position, label, property);
			EditorGUI.BeginChangeCheck();

			EditorGUI.PrefixLabel(position, label);
			position.yMin += EditorGUIUtility.singleLineHeight;

			// Display List

			var labelWidth = EditorGUIUtility.labelWidth;
			EditorGUIUtility.labelWidth -= ReorderableList.Defaults.dragHandleWidth + PaddingLeft;

			using (new EditorGUI.IndentLevelScope(-EditorGUI.indentLevel))
			{
				m_List.DoList(position);
			}

			EditorGUIUtility.labelWidth = labelWidth;

			// Display other properties

			using (new EditorGUI.IndentLevelScope(3))
			{
				bool firstChild = true;
				property.ForEachChildren(prop =>
				{
					if (SerializedProperty.EqualContents(prop, m_List.serializedProperty))
					{
						return;
					}

					if (firstChild)
					{
						position.yMin += m_List.GetHeight() - EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
						position.xMax -= 60; // ~= footer buttons width
						firstChild = false;
					}

					var rect = position;
					rect.height = EditorGUI.GetPropertyHeight(prop, true);
					position.yMin += rect.height;

					EditorGUI.PropertyField(rect, prop, true);
				});
			}

			if (EditorGUI.EndChangeCheck())
			{
				property.serializedObject.ApplyModifiedProperties();
			}
			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			Init(property);

			float height = 0;
			property.ForEachChildren(prop =>
			{
				if (!SerializedProperty.EqualContents(prop, m_List.serializedProperty))
				{
					height += EditorGUI.GetPropertyHeight(prop, true);
				}
			});

			height += height == 0 ? EditorGUIUtility.singleLineHeight : EditorGUIUtility.standardVerticalSpacing;
			height += m_List.GetHeight();
			return height;
		}
	}
}