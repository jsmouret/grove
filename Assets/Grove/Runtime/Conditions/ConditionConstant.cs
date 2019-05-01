using System;
using UnityEngine;
using Grove.Common;
using Grove.Variables;

namespace Grove.Conditions
{
	[Serializable]
	public class ConditionOutput : OutputClass<Condition>, ICondition
	{
		public bool Evaluate(IContext context)
		{
			return Get().Evaluate(context);
		}
	}

	[CreateAssetMenu(fileName = "C_Condition", menuName = "Grove/Conditions/Condition Constant", order = 44)]
	public class ConditionConstant : Constant<Condition, ConditionConstant>, ICondition
	{
		public bool Evaluate(IContext context)
		{
			return Get().Evaluate(context);
		}
	}
}
