using System;
using UnityEngine;
using Grove.Common;
using Grove.Variables;

namespace Grove.Events
{
	[Serializable]
	public class EventOutput : OutputClass<Event>, IEvent
	{
		public void OnAttach(IEventContext context)
		{
			Get().OnAttach(context);
		}

		public void OnDetach(IEventContext context)
		{
			Get().OnDetach(context);
		}

		public bool Raised(IContext context, EventSource eventSource)
		{
			return Get().Raised(context, eventSource);
		}
	}

	[CreateAssetMenu(fileName = "C_Event", menuName = "Grove/Events/Event Constant", order = 46)]
	public class EventConstant : Constant<Event, EventConstant>, IEvent
	{
		public void OnAttach(IEventContext context)
		{
			Get().OnAttach(context);
		}

		public void OnDetach(IEventContext context)
		{
			Get().OnDetach(context);
		}

		public bool Raised(IContext context, EventSource eventSource)
		{
			return Get().Raised(context, eventSource);
		}
	}
}
