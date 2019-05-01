using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Grove.Common.Editor
{
	[CustomPropertyDrawer(typeof(Variant), true)]
	public class VariantPropertyDrawer : PropertyDrawer
	{
		private VariantType m_Type = null;
		private Dictionary<string, int> m_Hints = null;

		private void Init()
		{
			if (m_Type != null)
			{
				return;
			}

			m_Type = VariantType.Get(fieldInfo.FieldType);
			m_Hints = new Dictionary<string, int>();
		}

		private SerializedProperty GetSelection(SerializedProperty property, out int index)
		{
			var key = property.propertyPath;
			if (m_Hints.TryGetValue(key, out index) && index != 0)
			{
				var hint = property.FindPropertyRelative(m_Type.Nodes[index].FullName);
				if (hint != null && hint.arraySize != 0)
				{
					return hint.GetArrayElementAtIndex(0);
				}
			}

			index = 0;
			var selection = IterateNode(property, m_Type.Nodes[0], ref index);
			m_Hints[key] = index;
			return selection;
		}

		private SerializedProperty IterateNode(SerializedProperty property, VariantNode parent, ref int index)
		{
			foreach (var node in parent.Children)
			{
				var prop = property.FindPropertyRelative(node.Name);
				if (prop == null)
				{
					return null;
				}

				if (prop.arraySize == 0)
				{
					continue;
				}

				prop = prop.GetArrayElementAtIndex(0);

				if (node.Index != 0)
				{
					index = node.Index;
					return prop;
				}

				if (node.Children != null)
				{
					return IterateNode(prop, node, ref index);
				}
			}
			return null;
		}

		private SerializedProperty SetSelection(SerializedProperty property, int index)
		{
			m_Hints[property.propertyPath] = index;

			foreach (var node in m_Type.Nodes[0].Children)
			{
				var prop = property.FindPropertyRelative(node.Name);
				if (prop == null)
				{
					Debug.LogAssertion($"{node.Type} is not [Serializable]", property.serializedObject.targetObject);
					return null;
				}
				prop.arraySize = 0;
			}

			if (index == 0)
			{
				return null;
			}

			foreach (var node in m_Type.Nodes[index].Path)
			{
				var prop = property.FindPropertyRelative(node.Name);
				if (prop == null)
				{
					Debug.LogAssertion($"{node.Type} is not [Serializable]", property.serializedObject.targetObject);
					return null;
				}
				prop.arraySize = 1;
				property = prop.GetArrayElementAtIndex(0);
			}

			property.ResetValue();
			return property;
		}


		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			Init();

			label = EditorGUI.BeginProperty(position, label, property);
			EditorGUI.BeginChangeCheck();

			var popup = position;
			popup.height = EditorGUIUtility.singleLineHeight;

			var selection = GetSelection(property, out int index);
			var newIndex = EditorGUI.Popup(popup, label, index, m_Type.Options);
			if (index != newIndex)
			{
				selection = SetSelection(property, newIndex);
				if (selection != null)
				{
					selection.isExpanded = true;
				}
			}

			if (selection != null)
			{
				EditorGUI.PropertyField(position, selection, GUIContent.none, true);
			}

			if (EditorGUI.EndChangeCheck())
			{
				property.serializedObject.ApplyModifiedProperties();
			}
			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			Init();

			var selection = GetSelection(property, out int index);

			return selection != null
				? EditorGUI.GetPropertyHeight(selection, true)
				: EditorGUIUtility.singleLineHeight;
		}
	}
}