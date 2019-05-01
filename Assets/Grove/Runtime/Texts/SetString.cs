using System;
using UnityEngine;
using Grove.Actions;
using Grove.Common;
using Grove.Properties;

namespace Grove.Texts
{
	[Serializable]
	public class SetString : PropertySetter<string, StringProperty>
	{
		protected enum Operator
		{
			Assign,
			Append,
		}

		[SerializeField]
		protected Operator m_Operator;
		[SerializeField]
		protected StringInput m_Value;

		protected override string Evaluate(IContext context)
		{
			var a = m_Target.Load(context);
			var b = m_Value.Get(context);

			switch (m_Operator)
			{
				case Operator.Assign: return b;
				case Operator.Append: return a + b;
				default:
					Debug.LogAssertion($"Unkown Operator {m_Operator}");
					return default;
			}
		}
	}
}
