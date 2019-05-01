using System;
using UnityEngine;
using Grove.Common;
using Grove.Maths;

namespace Grove.Conditions
{
	public interface ICondition
	{
		bool Evaluate(IContext context);
	}

	public abstract class ConditionBase : ICondition
	{
		[SerializeField]
		protected BoolInput m_Not;

		public bool Evaluate(IContext context)
		{
			bool not = m_Not.Get(context);
			bool result = DoEvaluate(context);
			return not ? !result : result;
		}

		protected abstract bool DoEvaluate(IContext context);
	}

	[Serializable]
	public sealed class Condition : ReorderableArray<ConditionVariant>, ICondition
	{
		private enum Operator
		{
			And,
			Or,
		}

		[SerializeField]
		private Operator m_Operator = Operator.And;

		public bool Evaluate(IContext context)
		{
			switch (m_Operator)
			{
				case Operator.And:
					return EvaluateAnd(context);
				case Operator.Or:
					return EvaluateOr(context);
				default:
					return false;
			}
		}

		private bool EvaluateAnd(IContext context)
		{
			foreach (var item in m_Items)
			{
				var condition = item.Value;
				if (condition == null || !condition.Evaluate(context))
				{
					return false;
				}
			}
			return true;
		}

		private bool EvaluateOr(IContext context)
		{
			foreach (var item in m_Items)
			{
				var condition = item.Value;
				if (condition != null && condition.Evaluate(context))
				{
					return true;
				}
			}
			return false;
		}
	}
}
