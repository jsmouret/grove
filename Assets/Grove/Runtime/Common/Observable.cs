using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Grove.Variables
{
	public delegate void Callback();

	public interface IObservable
	{

		bool IsChanging();
		void Subscribe(Callback callback);
		void Unsubscribe(Callback callback);
	}

	public class Observable : IObservable
	{
		private Dictionary<Callback, int> m_Observers;
		private bool m_IsChanging;

		public bool HasObservers()
		{
			return m_Observers != null;
		}

		public bool IsChanging()
		{
			return m_IsChanging;
		}

		public void Change()
		{
			Assert.IsFalse(m_IsChanging, "Loop detected");

			if (m_Observers != null)
			{
				m_IsChanging = true;

				foreach (var callback in m_Observers.Keys)
				{
					try
					{
						callback();
					}
					catch (Exception e)
					{
						Debug.LogException(e);
					}
				}

				m_IsChanging = false;
			}
		}

		public void Subscribe(Callback callback)
		{
			Assert.IsFalse(m_IsChanging, "Cannot Subscribe while Observable is changing");

			if (m_Observers == null)
			{
				m_Observers = new Dictionary<Callback, int>()
				{
					{ callback, 1 },
				};
			}
			else if (m_Observers.TryGetValue(callback, out var count))
			{
				m_Observers[callback] = count + 1;
			}
			else
			{
				m_Observers.Add(callback, 1);
			}
		}

		public void Unsubscribe(Callback callback)
		{
			Assert.IsFalse(m_IsChanging, "Cannot Unsubscribe while Observable is changing");

			int count = m_Observers[callback];
			if (count > 1)
			{
				m_Observers[callback] = count - 1;
			}
			else
			{
				m_Observers.Remove(callback);

				if (m_Observers.Count == 0)
				{
					m_Observers = null;
				}
			}
		}
	}
}