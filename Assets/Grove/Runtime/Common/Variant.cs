using System;
using System.Reflection;
using UnityEngine;

namespace Grove.Common
{
	public abstract class Variant
	{
	}

	public class Variant<T> : Variant, ISerializationCallbackReceiver
		where T : class
	{
		public T Value
		{
			get
			{
				return m_Value;
			}
		}

		private T m_Value = null;

		public void OnAfterDeserialize()
		{
			object next = this;
			Type type = GetType();

			while (next != null)
			{
				var current = next;
				next = null;

				var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (var field in fields)
				{
					// Array is not empty, that's the selected path
					if (field.GetValue(current) is Array array && array.Length != 0)
					{
						next = array.GetValue(0);
						type = field.FieldType.GetElementType();

						// Recurse in struct namespace
						if (type.IsValueType)
						{
							break;
						}

						m_Value = next as T;
						return;
					}
				}
			}

			m_Value = null;
		}

		public void OnBeforeSerialize()
		{
		}
	}
}
