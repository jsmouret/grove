using System;
using UnityEngine;
using Grove.Common;
using Grove.Maths;

namespace Grove.Events
{
	public abstract class ComponentEvent<TComponent> : EventBase
	{
		[SerializeField]
		protected TComponent m_TargetOverride;

		private TComponent FindTarget(IContext context)
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

		public sealed override void Attach(IContext context)
		{
			Attach(context, FindTarget(context));
		}

		public sealed override void Detach(IContext context)
		{
			Detach(context, FindTarget(context));
		}

		protected sealed override bool IsRaised(IContext context, EventSource eventSource)
		{
			return IsRaised(context, eventSource, FindTarget(context));
		}

		protected abstract void Attach(IContext context, TComponent component);
		protected abstract void Detach(IContext context, TComponent component);
		protected abstract bool IsRaised(IContext context, EventSource eventSource, TComponent component);
	}
}
