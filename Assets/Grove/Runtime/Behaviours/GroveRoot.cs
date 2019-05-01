using System;
using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
using Grove.Common;

namespace Grove.Behaviours
{
	public class GroveRoot : GroveBehaviour
	{
		private static HashSet<GroveRoot> s_Instances = null;
#if UNITY_EDITOR
		public static HashSet<GroveRoot> EditorGetInstances() => s_Instances;
#endif

		public static HashSet<GroveRoot> GetInstances()
		{
			if (s_Instances == null)
			{
				// After an assembly reload, Awake is not called on already loaded gameobjects
				// so search again for all roots

				s_Instances = new HashSet<GroveRoot>();
				s_Instances.UnionWith(FindObjectsOfType<GroveRoot>());
			}
			return s_Instances;
		}

		public virtual void Awake()
		{
			if (s_Instances == null)
			{
				s_Instances = new HashSet<GroveRoot>();
			}

			s_Instances.Add(this);
		}

		public override void OnDestroy()
		{
			s_Instances.Remove(this);
			base.OnDestroy();
		}
	}
}
