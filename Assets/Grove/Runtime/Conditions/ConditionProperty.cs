using System;
using UnityEngine;
using Grove.Common;
using Grove.Properties;

namespace Grove.Conditions
{
	[Serializable]
	public class ConditionInput : AbstractInput<Condition, ConditionProperty, ConditionConstant>, ICondition
	{
		public bool Evaluate(IContext context)
		{
			return Get(context).Evaluate(context);
		}
	}

	[CreateAssetMenu(fileName = "MyCondition", menuName = "Grove/Conditions/Condition Property", order = 45)]
	public class ConditionProperty : Property<Condition>, ICondition
	{
		public bool Evaluate(IContext context)
		{
			return Load(context).Evaluate(context);
		}
	}
}
