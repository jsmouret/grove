using System;
using UnityEngine;
using Grove.Common;
using Grove.Conditions;

namespace Grove.Maths
{
	[Serializable]
	public class TestBool : ConditionBase
	{
		protected enum Operator
		{
			EqualTo,
			NotEqualTo,
		}

		[SerializeField]
		protected BoolInput m_A;
		[SerializeField]
		protected Operator m_Operator;
		[SerializeField]
		protected BoolInput m_B;

		protected override bool DoEvaluate(IContext context)
		{
			var a = m_A.Get(context);
			var b = m_B.Get(context);

			switch (m_Operator)
			{
				case Operator.EqualTo: return a == b;
				case Operator.NotEqualTo: return a != b;
				default:
					Debug.LogAssertion($"Unknown Operator {m_Operator}");
					return false;
			}
		}
	}
}
