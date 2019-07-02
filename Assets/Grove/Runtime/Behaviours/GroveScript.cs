using System;
using UnityEngine;
using Grove.Common;
using Grove.Events;

namespace Grove.Behaviours
{
	public class GroveScript : GroveBehaviour, IEventContext
	{
		[SerializeField]
		protected Grove.Events.Event m_When;

		[SerializeField]
		protected Grove.Conditions.Condition m_If;

		[SerializeField]
		protected Grove.Actions.Action m_Then;

		[SerializeField]
		protected Grove.Actions.Action m_Else;

		public override void OnEnable()
		{
			base.OnEnable();

			m_When.OnAttach(this);
			Evaluate(EventSource.OnEnable);
		}

		public override void OnDisable()
		{
			Evaluate(EventSource.OnDisable);
			m_When.OnDetach(this);

			base.OnDisable();
		}

		public void OnEvent()
		{
			Evaluate(EventSource.OnEvent);
		}

		private void Evaluate(EventSource eventSource)
		{
			if (m_When.Raised(this, eventSource))
			{
				if (m_If.Evaluate(this))
				{
					m_Then.Execute(this);
				}
				else
				{
					m_Else.Execute(this);
				}
			}
		}
	}
}
