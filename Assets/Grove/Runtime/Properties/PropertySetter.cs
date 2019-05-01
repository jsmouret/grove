using System;
using UnityEngine;
using UnityEngine.Assertions;
using Grove.Actions;
using Grove.Common;
using Grove.Properties;

namespace Grove.Properties
{
	public abstract class PropertySetter<T, TProperty> : ActionBase
		where TProperty : Property<T>
	{
		[SerializeField]
		protected TProperty m_Target;

		protected sealed override void DoExecute(IContext context)
		{
			if (m_Target == null)
			{
				Debug.LogAssertion("Target is not set", context.GetBehaviour());
			}
			else
			{
				m_Target.Store(context, Evaluate(context));
			}
		}

		protected abstract T Evaluate(IContext context);
	}
}
