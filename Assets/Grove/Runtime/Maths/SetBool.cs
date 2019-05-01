using System;
using UnityEngine;
using Grove.Actions;
using Grove.Properties;

namespace Grove.Maths
{
	[Serializable]
	public class SetBool : PropertySetter<bool, BoolProperty>
	{
		protected enum Operator
		{
			Assign,
			Not,
			Or,
			And,
			Xor,
		}

		[SerializeField]
		protected Operator m_Operator;
		[SerializeField]
		protected BoolInput m_Value;

		protected override bool Evaluate(IActionContext context)
		{
			var a = m_Target.Load(context);
			var b = m_Value.Get(context);

			switch (m_Operator)
			{
				case Operator.Assign: return b;
				case Operator.Not: return !b;
				case Operator.Or: return a | b;
				case Operator.And: return a & b;
				case Operator.Xor: return a ^ b;
				default:
					Debug.LogAssertion($"Unkown Operator {m_Operator}");
					return default;
			}
		}
	}
}
