using System;
using UnityEngine;
using Grove.Properties;

namespace Grove.Visuals
{
	[Serializable]
	public class ColorInput : Input<Color, ColorProperty, ColorConstant>
	{
	}

	[CreateAssetMenu(fileName = "MyColor", menuName = "Grove/Visuals/Color Property", order = 71)]
	public class ColorProperty : Property<Color>
	{
	}
}
