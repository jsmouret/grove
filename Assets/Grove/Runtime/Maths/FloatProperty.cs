using System;
using UnityEngine;
using Grove.Properties;

namespace Grove.Maths
{
	[Serializable]
	public class FloatInput : Input<float, FloatProperty, FloatConstant>
	{
	}

	[CreateAssetMenu(fileName = "MyFloat", menuName = "Grove/Maths/Float Property", order = 53)]
	public class FloatProperty : Property<float>
	{
	}
}
