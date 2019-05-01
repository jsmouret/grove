using System;
using UnityEngine;
using Grove.Properties;

namespace Grove.Maths
{
	[Serializable]
	public class Vector4Input : Input<Vector4, Vector4Property, Vector4Constant>
	{
	}

	[CreateAssetMenu(fileName = "MyVector4", menuName = "Grove/Maths/Vector4 Property", order = 61)]
	public class Vector4Property : Property<Vector4>
	{
	}
}
