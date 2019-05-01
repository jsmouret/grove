using System;
using UnityEngine;
using Grove.Common;
using Grove.Variables;

namespace Grove.Properties
{
	[Serializable]
	public class PropertyArrayInput : Input<PropertyArray, PropertyArrayProperty, PropertyArrayConstant>, IObservableContext
	{
		public bool IsChanging(IContext context)
		{
			return Get(context).IsChanging(context);
		}

		public void Subscribe(IContext context, Callback callback)
		{
			Get(context).Subscribe(context, callback);
		}

		public void Unsubscribe(IContext context, Callback callback)
		{
			Get(context).Unsubscribe(context, callback);
		}
	}

	[CreateAssetMenu(fileName = "MyPropertyArray", menuName = "Grove/Properties/PropertyArray Property", order = 65)]
	public class PropertyArrayProperty : Property<PropertyArray>
	{
	}
}
