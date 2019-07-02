using System;
using System.Collections;
using UnityEngine;
using Grove.Properties;

namespace Grove.Containers
{
	[Serializable]
	public class ListInput : AbstractInput<IList, ListProperty, ListConstant>
	{
	}

	public abstract class ListProperty : Property<IList>
	{
	}

	public class ListProperty<T> : ListProperty
	{
	}
}
