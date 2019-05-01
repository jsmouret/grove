using System;
using UnityEngine;
using Grove.Common;
using Grove.Variables;

namespace Grove.Properties
{
	[Serializable]
	public class PropertyArray : ReorderableArray<Property>, IObservableContext
	{
		public bool IsChanging(IContext context)
		{
			foreach (var item in m_Items)
			{
				if (item.IsChanging(context))
				{
					return true;
				}
			}
			return false;
		}

		public void Subscribe(IContext context, Callback callback)
		{
			foreach (var item in m_Items)
			{
				item.Subscribe(context, callback);
			}
		}

		public void Unsubscribe(IContext context, Callback callback)
		{
			foreach (var item in m_Items)
			{
				item.Unsubscribe(context, callback);
			}
		}
	}
}
