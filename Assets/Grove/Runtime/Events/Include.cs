using System;
using UnityEngine;
using UnityEngine.Assertions;
using Grove.Common;

namespace Grove.Events
{
	[Serializable]
	public class Include : EventBase
	{
		[SerializeField]
		protected EventInput m_Include;

		public override void Attach(IContext context)
		{
			m_Include.Get(context).Attach(context);
		}

		public override void Detach(IContext context)
		{
			m_Include.Get(context).Detach(context);
		}

		protected override bool IsRaised(IContext context, EventSource eventSource)
		{
			return m_Include.Get(context).Raised(context, eventSource);
		}
	}
}
