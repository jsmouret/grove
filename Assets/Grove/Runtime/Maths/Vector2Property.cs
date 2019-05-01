using System;
using UnityEngine;
using Grove.Properties;

namespace Grove.Maths
{
	[Serializable]
	public class Vector2Input : Input<Vector2, Vector2Property, Vector2Constant>
	{
	}

	[CreateAssetMenu(fileName = "MyVector2", menuName = "Grove/Maths/Vector2 Property", order = 57)]
	public class Vector2Property : Property<Vector2>
	{
	}
}
