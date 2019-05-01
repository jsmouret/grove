using System;
using UnityEngine;
using Grove.Variables;

namespace Grove.Visuals
{
	[Serializable]
	public class ColorOutput : OutputValue<Color>
	{
		ColorOutput()
		{
			m_Value = Color.white;
		}
	}

	[CreateAssetMenu(fileName = "C_Color", menuName = "Grove/Visuals/Color Constant", order = 70)]
	public class ColorConstant : Constant<Color, ColorConstant>
	{
		ColorConstant()
		{
			m_Value = Color.white;
		}
	}
}
