using System;
using Grove.Common;
using Grove.Events;

namespace Grove.Behaviours
{
	[Serializable]
	public class OnEnable : EventBase
	{
		protected override bool IsRaised(IContext context, EventSource eventSource)
		{
			return eventSource == EventSource.OnEnable;
		}
	}
}
