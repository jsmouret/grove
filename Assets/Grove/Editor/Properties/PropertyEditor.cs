using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using Grove.Behaviours;
using Grove.Common;

namespace Grove.Properties.Editor
{
	[CustomEditor(typeof(Property), true)]
	public class PropertyEditor : UnityEditor.Editor
	{
		public override bool RequiresConstantRepaint()
		{
			return true;
		}

		public override void OnInspectorGUI()
		{
			base.DrawDefaultInspector();

			using (new EditorGUI.DisabledGroupScope(true))
			{
				DrawCache();
				DrawRoots();
			}
		}

		private void DrawCache()
		{
			var property = serializedObject.targetObject as Property;
			var cache = property.EditorGetCache();
			if (cache == null)
			{
				return;
			}

			EditorGUILayout.Separator();
			EditorGUILayout.LabelField($"Cache #{cache.Count}");

			foreach (var entry in cache)
			{
				var behaviour = entry.Key.GetBehaviour();
				var reference = entry.Value.TryGetTarget(out var target)
					? target.GetHashCode().ToString()
					: "null";

				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.ObjectField(behaviour, typeof(MonoBehaviour), false);
				EditorGUILayout.LabelField(reference);
				EditorGUILayout.EndHorizontal();
			}
		}

		private void DrawRoots()
		{
			var roots = GroveRoot.EditorGetInstances();
			if (roots == null)
			{
				return;
			}

			EditorGUILayout.Separator();
			EditorGUILayout.LabelField($"Roots #{roots.Count}");

			foreach (var root in roots)
			{
				var info = root != null
					? root.GetHashCode().ToString()
					: "null";

				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.ObjectField(root, typeof(GroveRoot), false);
				EditorGUILayout.LabelField(info);
				EditorGUILayout.EndHorizontal();
			}
		}
	}
}