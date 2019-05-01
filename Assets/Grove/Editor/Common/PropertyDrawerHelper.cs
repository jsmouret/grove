using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Grove.Common.Editor
{
	internal class PropertyDrawerHelper
	{
		public static Type GetTargetType(Type type)
		{
			// PropertyDrawers are also used for lists and arrays of the given fieldType

			if (type.IsArray)
			{
				return type.GetElementType();
			}

			if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
			{
				return type.GenericTypeArguments[0];
			}

			return type;
		}
	}
}