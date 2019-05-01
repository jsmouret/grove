using System;
using UnityEngine;
using Grove.Variables;

namespace Grove.Maths
{
	[Serializable]
	public class BoolOutput : OutputValue<bool>
	{
	}

	[CreateAssetMenu(fileName = "C_Bool", menuName = "Grove/Maths/Bool Constant", order = 50)]
	public class BoolConstant : Constant<bool, BoolConstant>
	{
	}
}
