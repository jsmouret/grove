using System;
using UnityEngine;
using UnityEngine.Assertions;
using Grove.Common;
using Grove.Variables;

namespace Grove.Properties
{
	public interface IInput<T>
	{
		T Get(IContext context);
	}

	public class InputBaseForEditor : Observable
	{
	}

	[Serializable]
	public class Input : BasicInput<object, Property, Constant>
	{
	}

	public class BasicInput<T, TProperty, TConstant> : InputBaseForEditor, IInput<T>
		where TProperty : class, IProperty<T>
		where TConstant : class, IConstant<T>
	{
		protected enum Option
		{
			Constant,
			Property,
		}

		[SerializeField]
		protected Option m_Option;

		[SerializeField]
		protected TConstant m_Constant;

		[SerializeField]
		protected TProperty m_Property;

		public T Get(IContext context)
		{
			switch (m_Option)
			{
				case Option.Constant:
					Assert.IsNotNull(m_Constant, "Input Constant is not set");
					return m_Constant.Get();
				case Option.Property:
					Assert.IsNotNull(m_Property, "Input Property is not set");
					return m_Property.Load(context);
				default:
					Debug.LogAssertion("Unknown Input Option");
					return default;
			}
		}
	}

	public class Input<T, TProperty, TConstant> : InputBaseForEditor, IInput<T>
		where TProperty : class, IProperty<T>
		where TConstant : class, IConstant<T>
	{
		protected enum Option
		{
			Value,
			Constant,
			Property,
		}

		[SerializeField]
		protected Option m_Option;

		[SerializeField]
		protected T m_Value;

		[SerializeField]
		protected TConstant m_Constant;

		[SerializeField]
		protected TProperty m_Property;

		public T Get(IContext context)
		{
			switch (m_Option)
			{
				case Option.Value:
					return m_Value;
				case Option.Constant:
					Assert.IsNotNull(m_Constant, "Input Constant is not set");
					return m_Constant.Get();
				case Option.Property:
					Assert.IsNotNull(m_Property, "Input Property is not set");
					return m_Property.Load(context);
				default:
					Debug.LogAssertion("Unknown Input Option");
					return default;
			}
		}
	}
}