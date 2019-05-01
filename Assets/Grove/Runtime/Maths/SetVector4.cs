using System;
using UnityEngine;
using Grove.Common;
using Grove.Properties;

namespace Grove.Maths
{
	[Serializable]
	public class SetVector4 : PropertySetter<Vector4, Vector4Property>
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
		protected Vector4Input m_Value;

		protected override Vector4 Evaluate(IContext context)
		{
			var a = m_Target.Load(context);
			var b = m_Value.Get(context);

			switch (m_Operator)
			{
				case Operator.Assign: return b;
				case Operator.Add: return a + b;
				case Operator.Substract: return a - b;
				case Operator.Multiply: return Vector4.Scale(a, b);
				case Operator.Divide: return Vector4.Scale(a, new Vector4(1 / b.x, 1 / b.y, 1 / b.z, 1 / b.w));
				case Operator.Min: return Vector4.Min(a, b);
				case Operator.Max: return Vector4.Max(a, b);
				default:
					Debug.LogAssertion($"Unkown Operator {m_Operator}");
					return default;
			}
		}
	}
}
