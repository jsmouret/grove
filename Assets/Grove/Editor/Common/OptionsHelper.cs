using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace Grove.Common.Editor
{
	internal class OptionsHelper
	{
		private const string OptionPropertyName = "m_Option";
		private static readonly GUIStyle s_OptionsStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
		{
			imagePosition = ImagePosition.ImageOnly,
		};

		private readonly Enum[] m_Values;
		private readonly string[] m_PropertyNames;

		public OptionsHelper(Type enumType)
		{
			var enumValues = enumType.GetEnumValues();
			var enumNames = enumType.GetEnumNames();
			var count = enumValues.Length;

			m_Values = new Enum[count];
			m_PropertyNames = new string[count];

			for (int i = 0; i < count; ++i)
			{
				m_Values[i] = enumValues.GetValue(i) as Enum;
				m_PropertyNames[i] = $"m_{enumNames[i]}";
			}
		}

		public delegate SerializedProperty GetProperty(string propertyPath);

		public bool DoGUI(GetProperty getProperty, Rect position, GUIContent label)
		{
			EditorGUI.BeginChangeCheck();

			var option = getProperty(OptionPropertyName);
			var selection = getProperty(m_PropertyNames[option.enumValueIndex]);

			using (new EditorGUI.IndentLevelScope(-EditorGUI.indentLevel))
			{
				var optionPosition = new Rect(
						position.x
							- s_OptionsStyle.fixedWidth - s_OptionsStyle.margin.right
							+ EditorGUIUtility.labelWidth,
						position.y + s_OptionsStyle.margin.top + s_OptionsStyle.padding.top,
						s_OptionsStyle.fixedWidth + s_OptionsStyle.margin.right,
						s_OptionsStyle.lineHeight);

				if (string.IsNullOrEmpty(label.text))
				{
					optionPosition.x = position.x;
					position.xMin = optionPosition.xMax;

					if (selection.hasVisibleChildren)
					{
						// leave space for the foldout icon ~= ReorderableArray.PaddingLeft
						optionPosition.x -= 10;
					}
				}

				var oldOption = m_Values[option.enumValueIndex];
				var newOption = EditorGUI.EnumPopup(optionPosition, GUIContent.none, oldOption, s_OptionsStyle);
				if (!newOption.Equals(oldOption))
				{
					option.enumValueIndex = Convert.ToInt32(newOption);
					selection = getProperty(m_PropertyNames[option.enumValueIndex]);

					foreach (var prop in m_PropertyNames)
					{
						getProperty(prop).ResetValue();
					}
				}
			}

			if (selection != null)
			{
				EditorGUI.PropertyField(position, selection, label, true);
			}

			return EditorGUI.EndChangeCheck();
		}

		public float GetHeight(GetProperty getProperty, GUIContent label)
		{
			var option = getProperty(OptionPropertyName);
			var selection = getProperty(m_PropertyNames[option.enumValueIndex]);
			if (selection != null)
			{
				return EditorGUI.GetPropertyHeight(selection, label, true);
			}
			return EditorGUIUtility.singleLineHeight;
		}

		// Cache

		private static readonly Dictionary<Type, OptionsHelper> s_TypeCache = new Dictionary<Type, OptionsHelper>();
		private static readonly Dictionary<Type, OptionsHelper> s_OptionCache = new Dictionary<Type, OptionsHelper>();

		public static OptionsHelper Get(Type type)
		{
			if (!s_TypeCache.TryGetValue(type, out var entry))
			{
				entry = Make(type);
				s_TypeCache[type] = entry;
			}
			return entry;
		}

		private static OptionsHelper Make(Type type)
		{
			var targetType = PropertyDrawerHelper.GetTargetType(type);
			var optionField = targetType.GetField(OptionPropertyName, BindingFlags.Instance | BindingFlags.NonPublic);
			var optionType = optionField.FieldType;

			if (!s_OptionCache.TryGetValue(optionType, out var entry))
			{
				entry = new OptionsHelper(optionType);
				s_OptionCache[optionType] = entry;
			}
			return entry;
		}
	}
}