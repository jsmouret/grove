using System;
using UnityEngine;
using Grove.Common;
using Grove.Properties;

namespace Grove.Actions
{
	[Serializable]
	public class SetAction : PropertySetter<Action, ActionProperty>
	{
		[SerializeField]
		protected ActionInput m_Value;

		protected override Action Evaluate(IContext context)
		{
			return m_Value.Get(context);
		}
	}
}
