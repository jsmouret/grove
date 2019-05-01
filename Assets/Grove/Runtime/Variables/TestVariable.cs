using System;
using UnityEngine;
using Grove.Common;
using Grove.Conditions;

namespace Grove.Variables
{
	[Serializable]
	public class TestVariable : ConditionBase
	{
		protected enum Operator
		{
			EqualTo,
		}

		[SerializeField]
		protected Variable m_A;
		[SerializeField]
		protected Operator m_Operator;
		[SerializeField]
		protected Variable m_B;

		protected override bool DoEvaluate(IContext context)
		{
			var a = m_A.Load(context);
			var b = m_B.Load(context);

			switch (m_Operator)
			{
				case Operator.EqualTo: return a == b;
				default:
					Debug.LogAssertion($"Unknown Operator {m_Operator}");
					return false;
			}
		}
	}
}
