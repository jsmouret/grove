using UnityEditor;
using UnityEngine;
using Grove.Common.Editor;

namespace Grove.Variables.Editor
{
	[CustomEditor(typeof(Constant), true)]
	public class ConstantEditor : UnityEditor.Editor
	{
		private static readonly GUIContent s_Label = new GUIContent("Constant");
		private OptionsHelper m_Helper = null;

		public void Init()
		{
			if (m_Helper == null)
			{
				m_Helper = OptionsHelper.Get(serializedObject.targetObject.GetType());
			}
		}

		protected SerializedProperty GetProperty(string propertyPath)
		{
			var prop = serializedObject.FindProperty(propertyPath);
			if (prop == null)
			{
				var target = serializedObject.targetObject;
				Debug.LogAssertion($"{target.GetType()}.{propertyPath} is not [Serializable]", target);
			}
			return prop;
		}

		public override void OnInspectorGUI()
		{
			Init();
			serializedObject.Update();

			using (new EditorGUI.DisabledScope(true))
			{
				EditorGUILayout.PropertyField(GetProperty("m_Script"), true);
			}

			var height = m_Helper.GetHeight(GetProperty, s_Label);
			var position = EditorGUILayout.GetControlRect(false, height);

			if (m_Helper.DoGUI(GetProperty, position, s_Label))
			{
				serializedObject.ApplyModifiedProperties();
			}
		}
	}
}