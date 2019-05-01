using System;
using UnityEngine;
using Grove.Common;
using Grove.Variables;

namespace Grove.Properties
{
	[Serializable]
	public class PropertyArrayOutput : OutputClass<PropertyArray>
	{
	}

	[CreateAssetMenu(fileName = "C_PropertyArray", menuName = "Grove/Properties/PropertyArray Constant", order = 64)]
	public class PropertyArrayConstant : Constant<PropertyArray, PropertyArrayConstant>
	{
	}
}
