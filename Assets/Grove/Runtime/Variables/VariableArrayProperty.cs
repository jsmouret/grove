using System;
using UnityEngine;
using Grove.Common;
using Grove.Properties;

namespace Grove.Variables
{
	[Serializable]
	public class VariableArrayInput : Input<VariableArray, VariableArrayProperty, VariableArrayConstant>, IVariableArray
	{
		public object[] LoadObjects(IContext context)
		{
			return Get(context).LoadObjects(context);
		}

		public void ReleaseObjects(IContext context)
		{
			Get(context).ReleaseObjects(context);
		}
	}

	[CreateAssetMenu(fileName = "MyVariableArray", menuName = "Grove/Variables/VariableArray Property", order = 69)]
	public class VariableArrayProperty : Property<VariableArray>
	{
	}
}
