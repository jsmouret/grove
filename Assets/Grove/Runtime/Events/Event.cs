using System;
using UnityEngine;
using Grove.Actions;
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

	public interface IEventContext : IActionContext
	{
		void OnEvent();
	}

	public interface IEvent
	{
		void Attach(IContext context);
		void Detach(IContext context);
		bool Raised(IContext context, EventSource eventSource);
	}

	public abstract class EventBase : IEvent
	{
		[SerializeField]
		protected BoolInput m_Mute;

		public virtual void Attach(IContext context)
		{
		}

		public virtual void Detach(IContext context)
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
		public void Attach(IContext context)
		{
			foreach (var item in m_Items)
			{
				item.Value?.Attach(context);
			}
		}

		public void Detach(IContext context)
		{
			foreach (var item in m_Items)
			{
				item.Value?.Detach(context);
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
