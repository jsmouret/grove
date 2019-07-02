using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Grove.Variables;

namespace Grove.Containers
{
	public abstract class ListOutput : Observable, IOutput<IList>
	{
		object IOutput.Get()
		{
			return GetList();
		}

		void IOutput.Set(object value)
		{
			SetList(value as IList);
		}

		IList IOutput<IList>.Get()
		{
			return GetList();
		}

		void IOutput<IList>.Set(IList value)
		{
			SetList(value);
		}

		protected abstract IList GetList();
		protected abstract void SetList(IList value);
	}

	[Serializable]
	public class ListOutput<T> : ListOutput, IOutput<List<T>>
	{
		[SerializeField]
		protected List<T> m_Items;

		protected sealed override IList GetList()
		{
			return m_Items;
		}

		protected sealed override void SetList(IList value)
		{
			Assert.IsTrue(value != null && value.GetType() == typeof(List<T>));
			Set(value as List<T>);
		}

		public List<T> Get()
		{
			return m_Items;
		}

		public void Set(List<T> value)
		{
			if (m_Items != value)
			{
				m_Items = value;
				Change();
			}
		}

		public T this[int index]
		{
			get
			{
				return m_Items[index];
			}
			set
			{
				m_Items[index] = value;
				Change();
			}
		}

		public void Add(T item)
		{
			m_Items.Add(item);
			Change();
		}
	}
}
