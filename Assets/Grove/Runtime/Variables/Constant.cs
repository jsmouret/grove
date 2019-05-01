using System;
using UnityEngine;
using Grove.Common;

namespace Grove.Variables
{
	public interface IConstant<T>
	{
		T Get();
	}

	public abstract class Constant : Variable, IConstant<object>
	{
		public sealed override object Load(IContext context)
		{
			return GetObject();
		}

		public object Get()
		{
			return GetObject();
		}

		protected abstract object GetObject();
	}

	public class Constant<T, TConstant> : Constant, IConstant<T>
		where TConstant : Constant<T, TConstant>
	{
		protected enum Option
		{
			Value,
			Constant,
		}

		[SerializeField]
		protected Option m_Option;

		[SerializeField]
		protected T m_Value;

		[SerializeField]
		protected TConstant m_Constant;

		protected sealed override object GetObject()
		{
			return Get();
		}

		public new T Get()
		{
			switch (m_Option)
			{
				case Option.Value:
					return m_Value;
				case Option.Constant:
					return m_Constant.Get();
				default:
					Debug.LogAssertion("Unknown Constant Option");
					return default;
			}
		}
	}
}
