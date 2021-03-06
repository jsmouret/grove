﻿using System;
using UnityEngine;
using Grove.Common;
using Grove.Events;

namespace Grove.Behaviours
{
	public class GroveScript : GroveBehaviour
	{
		[SerializeField]
		protected Grove.Events.Event m_When;

		[SerializeField]
		protected Grove.Conditions.Condition m_If;

		[SerializeField]
		protected Grove.Actions.Action m_Then;

		[SerializeField]
		protected Grove.Actions.Action m_Else;

		public void OnEnable()
		{
			m_When.Attach(this);
			Evaluate(EventSource.OnEnable);
		}

		public void OnDisable()
		{
			Evaluate(EventSource.OnDisable);
			m_When.Detach(this);
		}

		public override void OnEvent()
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
