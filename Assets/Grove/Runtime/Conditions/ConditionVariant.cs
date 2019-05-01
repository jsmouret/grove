using System;
using Grove.Common;

namespace Grove.Conditions
{
	[Serializable]
	public class ConditionVariant : Variant<ConditionBase>
	{
		[Serializable]
		public struct Conditions
		{
			public Grove.Conditions.Include[] m_Include;
		}

		[Serializable]
		public struct Maths
		{
			public Grove.Maths.TestBool[] m_TestBool;
			public Grove.Maths.TestFloat[] m_TestFloat;
			public Grove.Maths.TestInt[] m_TestInt;
		}

		[Serializable]
		public struct Texts
		{
			public Grove.Texts.TestString[] m_TestString;
		}

		[Serializable]
		public struct Variables
		{
			public Grove.Variables.TestVariable[] m_TestVariable;
		}

		public Conditions[] m_Conditions;
		public Maths[] m_Maths;
		public Texts[] m_Texts;
		public Variables[] m_Variables;
	}
}
