using System;
using UnityEngine;
using Grove.Variables;

namespace Grove.Maths
{
	[Serializable]
	public class QuaternionOutput : OutputValue<Quaternion>
	{
	}

	[CreateAssetMenu(fileName = "C_Quaternion", menuName = "Grove/Maths/Quaternion Constant", order = 60)]
	public class QuaternionConstant : Constant<Quaternion, QuaternionConstant>
	{
	}
}
