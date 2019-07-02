using System;
using UnityEngine;
using Grove.Common;
using Grove.Maths;

namespace Grove.Events
{
	public enum EventSource
	{
		OnEnable,
		OnDisable,
		OnEvent,
	}

	public interface IEvent
	{
		void OnAttach(IEventContext context);
		void OnDetach(IEventContext context);
		bool Raised(IContext context, EventSource eventSource);
	}

	public abstract class EventBase : IEvent
	{
		[SerializeField]
		protected BoolInput m_Mute;

		public virtual void OnAttach(IEventContext context)
		{
		}

		public virtual void OnDetach(IEventContext context)
		{
		}

		public bool Raised(IContext context, EventSource eventSource)
		{
			if (m_Mute.Get(context))
			{
				return false;
			}
			return IsRaised(context, eventSource);
		}

		protected abstract bool IsRaised(IContext context, EventSource eventSource);
	}

	[Serializable]
	public sealed class Event : ReorderableArray<EventVariant>, IEvent
	{
		public void OnAttach(IEventContext context)
		{
			foreach (var item in m_Items)
			{
				item.Value?.OnAttach(context);
			}
		}

		public void OnDetach(IEventContext context)
		{
			foreach (var item in m_Items)
			{
				item.Value?.OnDetach(context);
			}
		}

		public bool Raised(IContext context, EventSource eventSource)
		{
			foreach (var item in m_Items)
			{
				var evt = item.Value;
				if (evt != null && evt.Raised(context, eventSource))
				{
					return true;
				}
			}
			return false;
		}
	}
}
