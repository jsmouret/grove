using System;
using UnityEngine;
using Grove.Common;
using Grove.Properties;

namespace Grove.Visuals
{
	[Serializable]
	public class SetColor : PropertySetter<Color, ColorProperty>
	{
		protected enum Operator
		{
			Assign,
		}

		[SerializeField]
		protected Operator m_Operator;
		[SerializeField]
		protected ColorInput m_Value;

		protected override Color Evaluate(IContext context)
		{
			switch (m_Operator)
			{
				case Operator.Assign:
					return m_Value.Get(context);
				default:
					Debug.LogAssertion($"Unkown Operator {m_Operator}");
					return default;
			}
		}
	}
}