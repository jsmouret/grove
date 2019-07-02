using System;
using UnityEngine;
using Grove.Actions;
using Grove.Common;
using Grove.Maths;

namespace Grove.Behaviours
{
	[Serializable]
	public class SetEnabled : ActionBase
	{
		[SerializeField]
		protected Behaviour m_Target;
		[SerializeField]
		protected BoolInput m_Not;
		[SerializeField]
		protected BoolInput m_Enabled;

		protected override void DoExecute(IContext context)
		{
			var not = m_Not.Get(context);
			var enabled = m_Enabled.Get(context);

			m_Target.enabled = not ^ enabled;
		}
	}
}
