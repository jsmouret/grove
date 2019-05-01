using System;
using UnityEngine;
using Grove.Variables;

namespace Grove.Maths
{
	[Serializable]
	public class FloatOutput : OutputValue<float>
	{
	}

	[CreateAssetMenu(fileName = "C_Float", menuName = "Grove/Maths/Float Constant", order = 52)]
	public class FloatConstant : Constant<float, FloatConstant>
	{
	}
}
