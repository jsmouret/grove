using System.Collections.Generic;
using UnityEngine;
using Grove.Actions;
using Grove.Common;
using Grove.Properties;

namespace Grove.Behaviours
{
	public class GroveBehaviour : MonoBehaviour, IContext
	{
		private List<ContextAction> m_OnDestroy;

		// IContext

		public MonoBehaviour GetBehaviour()
		{
			return this;
		}

		public virtual void OnEvent()
		{
		}

		public void AddOnDestroy(ContextAction onDestroy)
		{
			if (m_OnDestroy == null)
			{
				m_OnDestroy = new List<ContextAction>();
			}
			m_OnDestroy.Add(onDestroy);
		}

		// MonoBehaviour

		public virtual void OnDestroy()
		{
			if (m_OnDestroy != null)
			{
				foreach (var onDestroy in m_OnDestroy)
				{
					onDestroy(this);
				}
			}
		}

		// Helpers

		protected T Get<T>(IInput<T> input)
		{
			return input.Get(this);
		}
	}
}
