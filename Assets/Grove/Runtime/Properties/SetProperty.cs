using System;
using UnityEngine;
using Grove.Actions;
using Grove.Common;

namespace Grove.Properties
{
	[Serializable]
	public class SetProperty : ActionBase
	{
		[SerializeField]
		protected Property m_Target;
		[SerializeField]
		protected Input m_Value;

		protected sealed override void DoExecute(IContext context)
		{
			if (m_Target == null)
			{
				Debug.LogAssertion("Target is not set", context.GetBehaviour());
			}
			else
			{
				m_Target.Store(context, m_Value?.Get(context));
			}
		}
	}
}
