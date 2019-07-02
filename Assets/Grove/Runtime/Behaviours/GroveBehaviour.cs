using System.Collections.Generic;
using UnityEngine;
using Grove.Common;
using Grove.Properties;
using Grove.Variables;

namespace Grove.Behaviours
{
	public abstract class GroveBehaviour : MonoBehaviour, IContext
	{
		// IContext

		public MonoBehaviour GetBehaviour()
		{
			return this;
		}

		// MonoBehaviour

		public virtual void Awake()
		{
		}

		public virtual void OnEnable()
		{
		}

		public virtual void OnDisable()
		{
		}

		public virtual void OnDestroy()
		{
		}

		// Helpers

		protected T Get<T>(IInput<T> input)
		{
			return input.Get(this);
		}
	}
}
