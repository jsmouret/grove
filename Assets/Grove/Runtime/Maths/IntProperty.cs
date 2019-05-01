using System;
using UnityEngine;
using Grove.Properties;

namespace Grove.Maths
{
	[Serializable]
	public class IntInput : Input<int, IntProperty, IntConstant>
	{
	}

	[CreateAssetMenu(fileName = "MyInt", menuName = "Grove/Maths/Int Property", order = 55)]
	public class IntProperty : Property<int>
	{
	}
}
