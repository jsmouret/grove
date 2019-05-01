using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Grove.Common.Editor
{
	internal class VariantNode
	{
		public Type Type;
		public string Name;
		public string FullName;
		public int Index;
		public Stack<VariantNode> Path;
		public List<VariantNode> Children;
	}

	internal class VariantType
	{
		public GUIContent[] Options;
		public List<VariantNode> Nodes;

		public VariantType(Type type)
		{
			var options = new List<GUIContent>
			{
				new GUIContent("None"),
			};

			Nodes = new List<VariantNode>{
				new VariantNode
				{
					Type = type,
					Children = new List<VariantNode>(),
				}
			};

			var path = new Stack<VariantNode>();
			AddChildren(options, Nodes[0], path);

			Options = options.ToArray();
		}

		private void AddChildren(List<GUIContent> options, VariantNode parent, Stack<VariantNode> path)
		{
			var fields = parent.Type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

			foreach (var field in fields)
			{
				var fieldType = field.FieldType;
				if (!fieldType.IsArray)
				{
					continue;
				}

				var node = new VariantNode
				{
					Type = fieldType.GetElementType(),
					Name = field.Name,
					FullName = $"{parent.FullName}{field.Name}",
				};
				parent.Children.Add(node);
				path.Push(node);

				// Is a "namespace" struct?
				if (node.Type.IsValueType)
				{
					node.Children = new List<VariantNode>();
					node.FullName = $"{node.FullName}.Array.data[0].";
					AddChildren(options, node, path);
					node.FullName = null; // unused after that
				}
				else
				{
					node.Index = options.Count;
					node.Path = new Stack<VariantNode>(path);

					var optionName = node.Type.FullName.Replace('.', '/');

					options.Add(new GUIContent(optionName));
					Nodes.Add(node);
				}

				path.Pop();
			}
		}

		private static readonly Dictionary<Type, VariantType> s_TypeCache = new Dictionary<Type, VariantType>();
		private static readonly Dictionary<Type, VariantType> s_VariantCache = new Dictionary<Type, VariantType>();

		public static VariantType Get(Type type)
		{
			if (!s_TypeCache.TryGetValue(type, out var entry))
			{
				entry = Make(type);
				s_TypeCache[type] = entry;
			}
			return entry;
		}

		private static VariantType Make(Type type)
		{
			var variantType = PropertyDrawerHelper.GetTargetType(type);

			if (!s_VariantCache.TryGetValue(variantType, out var entry))
			{
				entry = new VariantType(variantType);
				s_VariantCache[variantType] = entry;
			}
			return entry;
		}
	}
}