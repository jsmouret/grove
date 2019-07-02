using System;
using UnityEngine;
using Grove.Properties;

namespace Grove.Containers
{
	[Serializable]
	public class ListInput : AbstractInput<List, ListProperty, ListConstant>
	{
	}

	public abstract class ListProperty : Property<List>
	{
	}

	public class ListProperty<T> : ListProperty
	{
	}
}
