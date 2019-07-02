using UnityEngine;

namespace Grove.Events
{
	public abstract class ComponentEvent<TComponent> : EventBase
	{
		[SerializeField]
		protected TComponent m_TargetOverride;

		private TComponent FindTarget(IEventContext context)
		{
			if (m_TargetOverride != null)
			{
				return m_TargetOverride;
			}

			var target = context.GetBehaviour().GetComponent<TComponent>();
			if (target == null)
			{
				Debug.LogAssertion($"Cannot find target {typeof(TComponent)}", context.GetBehaviour());
			}
			return target;
		}

		public sealed override void OnAttach(IEventContext context)
		{
			OnAttach(context, FindTarget(context));
		}

		public sealed override void OnDetach(IEventContext context)
		{
			OnDetach(context, FindTarget(context));
		}

		protected sealed override bool IsRaised(IContext context, EventSource eventSource)
		{
			return IsRaised(context, eventSource, FindTarget(context));
		}

		protected abstract void OnAttach(IEventContext context, TComponent component);
		protected abstract void OnDetach(IEventContext context, TComponent component);
		protected abstract bool IsRaised(IEventContext context, EventSource eventSource, TComponent component);
	}
}
