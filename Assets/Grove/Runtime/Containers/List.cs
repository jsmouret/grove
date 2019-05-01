using System;
using UnityEngine;
using UnityEngine.Assertions;
using Grove.Variables;

namespace Grove.Containers
{
	public interface IList<T>
	{
		void Add(T item);
		T this[int index] { get; }
	}

	[Serializable]
	public abstract class List : IList<object>
	{
		public void Add(object item) => AddObject(item);
		public object this[int index] => GetItemObject(index);

		protected abstract void AddObject(object item);
		protected abstract object GetItemObject(int index);
	}

	[Serializable]
	public class List<T> : List, IList<T>
		where T : class
	{
		[SerializeField]
		protected System.Collections.Generic.List<T> m_Items = new System.Collections.Generic.List<T>();

		protected sealed override void AddObject(object item)
		{
			Assert.IsTrue(item == null || item.GetType().IsSubclassOf(typeof(T)));
			m_Items.Add(item as T);
		}

		protected sealed override object GetItemObject(int index)
		{
			return this[index];
		}

		public new T this[int index]
		{
			get { return m_Items[index]; }
		}

		public void Add(T item)
		{
			m_Items.Add(item);
		}
	}
}
