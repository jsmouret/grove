using System;
using UnityEngine;
using Grove.Actions;
using Grove.Properties;

namespace Grove.Containers
{
	[Serializable]
	public class SetList : PropertySetter<List, ListProperty>
	{
		protected enum Operator
		{
			Assign,
		}

		[SerializeField]
		protected Operator m_Operator;
		[SerializeField]
		protected ListInput m_Value;

		protected override List Evaluate(IActionContext context)
		{
			// var a = m_Target.Get(context);
			var b = m_Value.Get(context);

			switch (m_Operator)
			{
				case Operator.Assign: return b;
				default:
					Debug.LogAssertion($"Unkown Operator {m_Operator}");
					return default;
			}
		}
	}
}
