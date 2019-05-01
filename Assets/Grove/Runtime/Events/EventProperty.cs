using System;
using UnityEngine;
using Grove.Common;
using Grove.Properties;

namespace Grove.Events
{
	[Serializable]
	public class EventInput : BasicInput<Event, EventProperty, EventConstant>, IEvent
	{
		public void Attach(IContext context)
		{
			Get(context).Attach(context);
		}

		public void Detach(IContext context)
		{
			Get(context).Detach(context);
		}

		public bool Raised(IContext context, EventSource eventSource)
		{
			return Get(context).Raised(context, eventSource);
		}
	}

	[CreateAssetMenu(fileName = "MyEvent", menuName = "Grove/Events/Event Property", order = 47)]
	public class EventProperty : Property<Event>, IEvent
	{
		public void Attach(IContext context)
		{
			Load(context).Attach(context);
		}

		public void Detach(IContext context)
		{
			Load(context).Detach(context);
		}

		public bool Raised(IContext context, EventSource eventSource)
		{
			return Load(context).Raised(context, eventSource);
		}
	}
}
