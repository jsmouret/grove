using System;
using UnityEngine;
using Grove.Common;
using Grove.Conditions;

namespace Grove.Maths
{
	[Serializable]
	public class TestInt : ConditionBase
	{
		protected enum Operator
		{
			EqualTo,
			LessThan,
			GreaterThan,
			LessThanOrEqualTo,
			GreaterThanOrEqualTo,
		}

		[SerializeField]
		protected IntInput m_A;
		[SerializeField]
		protected Operator m_Operator;
		[SerializeField]
		protected IntInput m_B;

		protected override bool DoEvaluate(IContext context)
		{
			var a = m_A.Get(context);
			var b = m_B.Get(context);

			switch (m_Operator)
			{
				case Operator.EqualTo: return a == b;
				case Operator.LessThan: return a < b;
				case Operator.GreaterThan: return a > b;
				case Operator.LessThanOrEqualTo: return a <= b;
				case Operator.GreaterThanOrEqualTo: return a >= b;
				default:
					Debug.LogAssertion($"Unknown Operator {m_Operator}");
					return false;
			}
		}
	}
}
