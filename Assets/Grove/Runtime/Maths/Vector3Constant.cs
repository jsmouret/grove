using System;
using UnityEngine;
using Grove.Variables;

namespace Grove.Maths
{
	[Serializable]
	public class Vector3Output : OutputValue<Vector3>
	{
		public static implicit operator Vector3Output(Vector3 value)
		{
			return new Vector3Output()
			{
				m_Value = value,
			};
		}
	}

	[CreateAssetMenu(fileName = "C_Vector3", menuName = "Grove/Maths/Vector3 Constant", order = 58)]
	public class Vector3Constant : Constant<Vector3, Vector3Constant>
	{
	}
}
