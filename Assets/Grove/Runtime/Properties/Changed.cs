using System;
using UnityEngine;
using Grove.Common;
using Grove.Events;

namespace Grove.Properties
{
	[Serializable]
	public class Changed : EventBase
	{
		[SerializeField]
		protected PropertyArrayInput m_Properties;

		public override void Attach(IContext context)
		{
			m_Properties.Subscribe(context, context.OnEvent);
		}

		public override void Detach(IContext context)
		{
			m_Properties.Unsubscribe(context, context.OnEvent);
		}

		protected override bool IsRaised(IContext context, EventSource eventSource)
		{
			return eventSource == EventSource.OnEvent && m_Properties.IsChanging(context);
		}
	}
}
