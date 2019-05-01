using System;
using UnityEngine;
using Grove.Variables;

namespace Grove.Maths
{
	[Serializable]
	public class IntOutput : OutputValue<int>
	{
	}

	[CreateAssetMenu(fileName = "C_Int", menuName = "Grove/Maths/Int Constant", order = 54)]
	public class IntConstant : Constant<int, IntConstant>
	{
	}
}
