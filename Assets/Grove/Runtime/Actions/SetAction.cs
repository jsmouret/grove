using System;
using UnityEngine;
using Grove.Properties;

namespace Grove.Actions
{
	[Serializable]
	public class SetAction : PropertySetter<Action, ActionProperty>
	{
		[SerializeField]
		protected ActionInput m_Value;

		protected override Action Evaluate(IActionContext context)
		{
			return m_Value.Get(context);
		}
	}
}
