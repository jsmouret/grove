using UnityEditor;
using UnityEngine;
using Grove.Common.Editor;

namespace Grove.Properties.Editor
{
	[CustomPropertyDrawer(typeof(InputBaseForEditor), true)]
	public class InputPropertyDrawer : PropertyDrawer
	{
		private OptionsHelper m_Helper = null;
		private SerializedProperty m_Property = null;

		protected void Init(SerializedProperty property)
		{
			if (m_Helper == null)
			{
				m_Helper = OptionsHelper.Get(fieldInfo.FieldType);
			}

			m_Property = property;
		}

		protected SerializedProperty GetProperty(string propertyPath)
		{
			return m_Property.FindPropertyRelative(propertyPath);
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			Init(property);
			label = EditorGUI.BeginProperty(position, label, property);

			if (m_Helper.DoGUI(GetProperty, position, label))
			{
				property.serializedObject.ApplyModifiedProperties();

				if (Application.isPlaying)
				{
					var input = property.GetObject() as InputBaseForEditor;
					input.Change();
				}
			}

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			Init(property);
			return m_Helper.GetHeight(GetProperty, label);
		}
	}
}
