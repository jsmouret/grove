using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Grove.Common.Editor
{
	public static class SerializedPropertyExtensions
	{
		public delegate void SerializedPropertyAction(SerializedProperty property);

		public static void ForEachChildren(this SerializedProperty property, SerializedPropertyAction apply)
		{
			var it = property.Copy();
			var end = property.GetEndProperty(true);
			if (it.Next(true))
			{
				while (!SerializedProperty.EqualContents(it, end))
				{
					apply(it);

					if (!it.Next(false))
					{
						break;
					}
				}
			}
		}

		public static void ResetValue(this SerializedProperty property)
		{
			switch (property.propertyType)
			{
				case SerializedPropertyType.Generic:
					if (property.isArray)
					{
						property.arraySize = 0;
					}
					else
					{
						property.ForEachChildren(ResetValue);
					}
					break;
				case SerializedPropertyType.Integer:
					property.intValue = 0;
					break;
				case SerializedPropertyType.Boolean:
					property.boolValue = false;
					break;
				case SerializedPropertyType.Float:
					property.floatValue = 0.0f;
					break;
				case SerializedPropertyType.String:
					property.stringValue = null;
					break;
				case SerializedPropertyType.Color:
					property.colorValue = Color.white;
					break;
				case SerializedPropertyType.ObjectReference:
					property.objectReferenceValue = null;
					break;
				case SerializedPropertyType.LayerMask:
					property.intValue = 0;
					break;
				case SerializedPropertyType.Enum:
					property.enumValueIndex = 0;
					break;
				case SerializedPropertyType.Vector2:
					property.vector2Value = Vector2.zero;
					break;
				case SerializedPropertyType.Vector3:
					property.vector3Value = Vector3.zero;
					break;
				case SerializedPropertyType.Vector4:
					property.vector4Value = Vector4.zero;
					break;
				case SerializedPropertyType.Rect:
					property.rectValue = Rect.zero;
					break;
				case SerializedPropertyType.ArraySize:
					property.intValue = 0;
					break;
				case SerializedPropertyType.Character:
					property.intValue = 0;
					break;
				case SerializedPropertyType.AnimationCurve:
					property.animationCurveValue = null;
					break;
				case SerializedPropertyType.Bounds:
					property.boundsValue = new Bounds(Vector3.zero, Vector3.zero);
					break;
				case SerializedPropertyType.Gradient:
					// internal?
					// property.gradientValue = 0;
					break;
				case SerializedPropertyType.Quaternion:
					property.quaternionValue = Quaternion.identity;
					break;
				case SerializedPropertyType.ExposedReference:
					property.exposedReferenceValue = null;
					break;
				case SerializedPropertyType.FixedBufferSize:
					property.intValue = 0;
					break;
				case SerializedPropertyType.Vector2Int:
					property.vector2IntValue = Vector2Int.zero;
					break;
				case SerializedPropertyType.Vector3Int:
					property.vector3IntValue = Vector3Int.zero;
					break;
				case SerializedPropertyType.RectInt:
					property.rectIntValue = new RectInt(Vector2Int.zero, Vector2Int.zero);
					break;
				case SerializedPropertyType.BoundsInt:
					property.boundsIntValue = new BoundsInt(Vector3Int.zero, Vector3Int.zero);
					break;
				default:
					Debug.LogAssertion($"Unknown SerializedPropertyType {property.propertyType}");
					break;
			}
		}

		public static object GetObject(this SerializedProperty property)
		{
			object obj = property.serializedObject.targetObject;

			// TODO: support array
			var parts = property.propertyPath.Split('.');

			foreach (var part in parts)
			{
				var type = obj.GetType();
				var field = type.GetField(part, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				obj = field.GetValue(obj);
			}
			return obj;
		}
	}
}