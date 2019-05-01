using System;
using UnityEngine;
using Grove.Properties;

namespace Grove.Texts
{
	[Serializable]
	public class StringInput : Input<string, StringProperty, StringConstant>
	{
	}

	[CreateAssetMenu(fileName = "MyString", menuName = "Grove/Texts/String Property", order = 67)]
	public class StringProperty : Property<string>
	{
	}
}
