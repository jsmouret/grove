using System;
using UnityEngine;
using Grove.Common;
using Grove.Properties;

namespace Grove.Maths
{
	[Serializable]
	public class SetVector3 : PropertySetter<Vector3, Vector3Property>
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
		protected Vector3Input m_Value;

		protected override Vector3 Evaluate(IContext context)
		{
			var a = m_Target.Load(context);
			var b = m_Value.Get(context);

			switch (m_Operator)
			{
				case Operator.Assign: return b;
				case Operator.Add: return a + b;
				case Operator.Substract: return a - b;
				case Operator.Multiply: return Vector3.Scale(a, b);
				case Operator.Divide: return Vector3.Scale(a, new Vector3(1 / b.x, 1 / b.y, 1 / b.z));
				case Operator.Min: return Vector2.Min(a, b);
				case Operator.Max: return Vector2.Max(a, b);
				default:
					Debug.LogAssertion($"Unkown Operator {m_Operator}");
					return default;
			}
		}
	}
}
