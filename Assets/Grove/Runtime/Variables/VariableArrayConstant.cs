using System;
using UnityEngine;

namespace Grove.Variables
{
	[Serializable]
	public class VariableArrayOutput : OutputClass<VariableArray>
	{
	}

	[CreateAssetMenu(fileName = "C_VariableArray", menuName = "Grove/Variables/VariableArray Constant", order = 68)]
	public class VariableArrayConstant : Constant<VariableArray, VariableArrayConstant>
	{
	}
}
