using UnityEngine;

namespace Grove.Common
{
	public abstract class ReorderableArray
	{
	}

	public class ReorderableArray<T> : ReorderableArray
	{
		[SerializeField]
		protected T[] m_Items;
	}
}
