using System;
using System.Collections.Generic;
using Grove.Common;
using Grove.Events;
using Grove.Variables;

namespace Grove.UI
{
	[Serializable]
	public class ButtonClicked : ComponentEvent<UnityEngine.UI.Button>
	{
		private static readonly Dictionary<UnityEngine.UI.Button, Observable> m_Observables
			= new Dictionary<UnityEngine.UI.Button, Observable>();

		protected override void OnAttach(IEventContext context, UnityEngine.UI.Button button)
		{
			if (!m_Observables.TryGetValue(button, out var observable))
			{
				observable = new Observable();
				m_Observables[button] = observable;
				button.onClick.AddListener(observable.Change);
			}

			observable.Subscribe(context.OnEvent);
		}

		protected override void OnDetach(IEventContext context, UnityEngine.UI.Button button)
		{
			var observable = m_Observables[button];
			observable.Unsubscribe(context.OnEvent);

			if (!observable.HasObservers())
			{
				button.onClick.RemoveListener(observable.Change);
				m_Observables.Remove(button);
			}
		}

		protected override bool IsRaised(IContext context, EventSource eventSource, UnityEngine.UI.Button button)
		{
			return eventSource == EventSource.OnEvent && m_Observables[button].IsChanging();
		}
	}
}
