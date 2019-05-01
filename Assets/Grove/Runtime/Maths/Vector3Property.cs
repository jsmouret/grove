using System;
using UnityEngine;
using Grove.Properties;

namespace Grove.Maths
{
	[Serializable]
	public class Vector3Input : Input<Vector3, Vector3Property, Vector3Constant>
	{
	}

	[CreateAssetMenu(fileName = "MyVector3", menuName = "Grove/Maths/Vector3 Property", order = 59)]
	public class Vector3Property : Property<Vector3>
	{
	}
}
