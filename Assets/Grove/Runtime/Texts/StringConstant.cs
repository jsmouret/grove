using System;
using UnityEngine;
using Grove.Variables;

namespace Grove.Texts
{
	[Serializable]
	public class StringOutput : OutputValue<string>
	{
	}

	[CreateAssetMenu(fileName = "C_String", menuName = "Grove/Texts/String Constant", order = 66)]
	public class StringConstant : Constant<string, StringConstant>
	{
	}
}
