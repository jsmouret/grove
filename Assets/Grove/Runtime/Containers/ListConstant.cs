using System;
using UnityEngine;
using Grove.Variables;

namespace Grove.Containers
{
	[Serializable]
	public class ListOutput<T, TList> : OutputClass<TList>, IList<T>
		where T : class
		where TList : List<T>, new()
	{
		public ListOutput()
		{
			m_Value = new TList();
		}

		public void Add(T item) => m_Value.Add(item);
		public T this[int index] => m_Value[index];
	}

	public abstract class ListConstant : Constant<List, ListConstant>
	{
	}
}
