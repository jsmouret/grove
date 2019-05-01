using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Grove.Variables
{
	public interface IOutput : IObservable
	{
		object Get();
		void Set(object value);
	}

	public interface IOutput<T> : IOutput
	{
		new T Get();
		void Set(T value);
	}

	public abstract class OutputBaseForEditor : Observable
	{
	}

	public abstract class Output<T> : OutputBaseForEditor
	{
		[SerializeField]
		protected T m_Value;

		public T Get()
		{
			return m_Value;
		}

		public static implicit operator T(Output<T> output)
		{
			return output.m_Value;
		}
	}

	public class OutputValue<T> : Output<T>, IOutput<T>
		where T : IEquatable<T>
	{
		public void Set(T value)
		{
			if (!m_Value.Equals(value))
			{
				m_Value = value;
				Change();
			}
		}

		object IOutput.Get()
		{
			return Get();
		}

		void IOutput.Set(object value)
		{
			Assert.IsTrue(value == null || typeof(T).IsAssignableFrom(value.GetType()));
			Set((T)value);
		}
	}

	public class OutputClass<T> : Output<T>, IOutput<T>
		where T : class
	{
		public void Set(T value)
		{
			if (m_Value != value)
			{
				m_Value = value;
				Change();
			}
		}

		object IOutput.Get()
		{
			return Get();
		}

		void IOutput.Set(object value)
		{
			Assert.IsTrue(value == null || typeof(T).IsAssignableFrom(value.GetType()));
			Set(value as T);
		}
	}
}
