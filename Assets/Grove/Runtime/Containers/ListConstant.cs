using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Grove.Variables;

namespace Grove.Containers
{
	public abstract class ListConstant : Constant, IConstant<IList>
	{
		public new IList Get()
		{
			return GetList();
		}

		protected abstract IList GetList();
	}

	public class ListConstant<T, TListConstant> : ListConstant, IConstant<List<T>>
		where TListConstant : ListConstant<T, TListConstant>
	{
		protected enum Option
		{
			Value,
			Constant,
		}

		[SerializeField]
		protected Option m_Option;

		[SerializeField]
		protected List<T> m_Value;

		[SerializeField]
		protected TListConstant m_Constant;

		protected sealed override object GetObject()
		{
			return Get();
		}

		protected sealed override IList GetList()
		{
			return Get();
		}

		public new List<T> Get()
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
