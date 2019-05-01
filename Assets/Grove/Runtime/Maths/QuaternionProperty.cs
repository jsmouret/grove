using System;
using UnityEngine;
using Grove.Properties;

namespace Grove.Maths
{
	[Serializable]
	public class QuaternionInput : Input<Quaternion, QuaternionProperty, QuaternionConstant>
	{
	}

	[CreateAssetMenu(fileName = "MyQuaternion", menuName = "Grove/Maths/Quaternion Property", order = 61)]
	public class QuaternionProperty : Property<Quaternion>
	{
	}
}
