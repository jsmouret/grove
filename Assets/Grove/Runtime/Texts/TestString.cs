using System;
using UnityEngine;
using Grove.Common;
using Grove.Conditions;

namespace Grove.Texts
{
	[Serializable]
	public class TestString : ConditionBase
	{
		protected enum Operator
		{
			Equals,
			Contains,
			StartsWith,
			EndsWith,
		}

		[SerializeField]
		protected StringInput m_A;
		[SerializeField]
		protected Operator m_Operator;
		[SerializeField]
		protected StringInput m_B;

		protected override bool DoEvaluate(IContext context)
		{
			var a = m_A.Get(context);
			var b = m_B.Get(context);

			switch (m_Operator)
			{
				case Operator.Equals: return a.Equals(b);
				case Operator.Contains: return a.Contains(b);
				case Operator.StartsWith: return a.StartsWith(b);
				case Operator.EndsWith: return a.EndsWith(b);
				default:
					Debug.LogAssertion($"Unknown Operator {m_Operator}");
					return false;
			}
		}
	}
}
