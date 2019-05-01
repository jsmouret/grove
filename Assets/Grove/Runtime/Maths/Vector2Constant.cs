using System;
using UnityEngine;
using Grove.Variables;

namespace Grove.Maths
{
	[Serializable]
	public class Vector2Output : OutputValue<Vector2>
	{
	}

	[CreateAssetMenu(fileName = "C_Vector2", menuName = "Grove/Maths/Vector2 Constant", order = 56)]
	public class Vector2Constant : Constant<Vector2, Vector2Constant>
	{
	}
}
