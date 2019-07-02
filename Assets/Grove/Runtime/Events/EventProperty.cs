using System;
using UnityEngine;
using Grove.Common;
using Grove.Properties;

namespace Grove.Events
{
	[Serializable]
	public class EventInput : BasicInput<Event, EventProperty, EventConstant>, IEvent
	{
		public void OnAttach(IEventContext context)
		{
			Get(context).OnAttach(context);
		}

		public void OnDetach(IEventContext context)
		{
			Get(context).OnDetach(context);
		}

		public bool Raised(IContext context, EventSource eventSource)
		{
			return Get(context).Raised(context, eventSource);
		}
	}

	[CreateAssetMenu(fileName = "MyEvent", menuName = "Grove/Events/Event Property", order = 47)]
	public class EventProperty : Property<Event>, IEvent
	{
		public void OnAttach(IEventContext context)
		{
			Load(context).OnAttach(context);
		}

		public void OnDetach(IEventContext context)
		{
			Load(context).OnDetach(context);
		}

		public bool Raised(IContext context, EventSource eventSource)
		{
			return Load(context).Raised(context, eventSource);
		}
	}
}
