using UnityEditor;
using UnityEngine;
using Grove.Common.Editor;

namespace Grove.Variables.Editor
{
	[CustomPropertyDrawer(typeof(OutputBaseForEditor), true)]
	public class OutputPropertyDrawer : PropertyDrawer
	{
		private const string ValueProperty = "m_Value";

		private SerializedProperty GetValueProperty(SerializedProperty property)
		{
			return property.FindPropertyRelative(ValueProperty);
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginChangeCheck();

			var value = GetValueProperty(property);
			if (value != null)
			{
				EditorGUI.PropertyField(position, value, label, true);
			}
			else
			{
				Debug.LogAssertion($"{fieldInfo.FieldType}.{ValueProperty} is not [Serializable]", property.serializedObject.targetObject);
				EditorGUI.LabelField(position, label);
			}

			if (EditorGUI.EndChangeCheck())
			{
				property.serializedObject.ApplyModifiedProperties();

				if (Application.isPlaying)
				{
					var output = property.GetObject() as OutputBaseForEditor;
					output.Change();
				}
			}
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			var value = GetValueProperty(property);
			return value != null
				? EditorGUI.GetPropertyHeight(value, label, true)
				: EditorGUIUtility.singleLineHeight;
		}
	}
}
