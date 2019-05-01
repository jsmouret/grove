using System;
using UnityEngine;
using Grove.Properties;

namespace Grove.Maths
{
	[Serializable]
	public class BoolInput : Input<bool, BoolProperty, BoolConstant>
	{
	}

	[CreateAssetMenu(fileName = "MyBool", menuName = "Grove/Maths/Bool Property", order = 51)]
	public class BoolProperty : Property<bool>
	{
	}
}
