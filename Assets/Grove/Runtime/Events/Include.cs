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

		public override void OnAttach(IEventContext context)
		{
			m_Include.Get(context).OnAttach(context);
		}

		public override void OnDetach(IEventContext context)
		{
			m_Include.Get(context).OnDetach(context);
		}

		protected override bool IsRaised(IContext context, EventSource eventSource)
		{
			return m_Include.Get(context).Raised(context, eventSource);
		}
	}
}
