using System;
using UnityEngine;
using Grove.Common;
using Grove.Variables;

namespace Grove.Events
{
	[Serializable]
	public class EventOutput : OutputClass<Event>, IEvent
	{
		public void Attach(IContext context)
		{
			Get().Attach(context);
		}

		public void Detach(IContext context)
		{
			Get().Detach(context);
		}

		public bool Raised(IContext context, EventSource eventSource)
		{
			return Get().Raised(context, eventSource);
		}
	}

	[CreateAssetMenu(fileName = "C_Event", menuName = "Grove/Events/Event Constant", order = 46)]
	public class EventConstant : Constant<Event, EventConstant>, IEvent
	{
		public void Attach(IContext context)
		{
			Get().Attach(context);
		}

		public void Detach(IContext context)
		{
			Get().Detach(context);
		}

		public bool Raised(IContext context, EventSource eventSource)
		{
			return Get().Raised(context, eventSource);
		}
	}
}
