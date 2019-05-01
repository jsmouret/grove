using System;
using UnityEngine;
using Grove.Behaviours;
using Grove.Common;
using Grove.Variables;

namespace Grove.Properties
{
	public static class Resolver
	{
		public static IOutput<T> FromBehaviour<T>(string propertyPath, MonoBehaviour behaviour)
		{
			var path = propertyPath.Split('.');

			var gameObject = behaviour.gameObject;
			while (gameObject != null)
			{
				var components = gameObject.GetComponents<IContext>();
				foreach (var component in components)
				{
					var output = ResolveInObject<T>(path, component);
					if (output != null)
					{
						return output;
					}
				}
				gameObject = gameObject.transform.parent?.gameObject;
			}

			var roots = GroveRoot.GetInstances();
			foreach (var root in roots)
			{
				var output = ResolveInObject<T>(path, root);
				if (output != null)
				{
					return output;
				}
			}

			throw new Exception($"Cannot resolve {propertyPath} from {behaviour}");
		}

		private static IOutput<T> ResolveInObject<T>(string[] path, object obj)
		{
			var index = -1;
			while (obj != null && ++index < path.Length)
			{
				var name = path[index];
				var parent = obj;
				obj = null;

				if (parent is IOutput output)
				{
					parent = output.Get();
				}

				var fields = parent.GetType().GetFields();
				foreach (var field in fields)
				{
					if (field.Name.Equals(name))
					{
						obj = field.GetValue(parent);
						break;
					}
				}
			}
			return obj as IOutput<T>;
		}
	}
}
