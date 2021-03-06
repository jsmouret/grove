﻿using System;
using UnityEngine;
using Grove.Common;
using Grove.Properties;

namespace Grove.Maths
{
	[Serializable]
	public class SetInt : PropertySetter<int, IntProperty>
	{
		protected enum Operator
		{
			Assign,
			Add,
			Substract,
			Multiply,
			Divide,
			Min,
			Max,
		}

		[SerializeField]
		protected Operator m_Operator;
		[SerializeField]
		protected IntInput m_Value;

		protected override int Evaluate(IContext context)
		{
			var a = m_Target.Load(context);
			var b = m_Value.Get(context);

			switch (m_Operator)
			{
				case Operator.Assign: return b;
				case Operator.Add: return a + b;
				case Operator.Substract: return a - b;
				case Operator.Multiply: return a * b;
				case Operator.Divide: return a / b;
				case Operator.Min: return Math.Min(a, b);
				case Operator.Max: return Math.Max(a, b);
				default:
					Debug.LogAssertion($"Unkown Operator {m_Operator}");
					return default;
			}
		}
	}
}
