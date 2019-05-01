using System;
using UnityEngine;
using Grove.Variables;

namespace Grove.Maths
{
	[Serializable]
	public class Vector4Output : OutputValue<Vector4>
	{
	}

	[CreateAssetMenu(fileName = "C_Vector4", menuName = "Grove/Maths/Vector4 Constant", order = 60)]
	public class Vector4Constant : Constant<Vector4, Vector4Constant>
	{
	}
}
