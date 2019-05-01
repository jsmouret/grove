using System;
using UnityEngine;
using Grove.Common;

namespace Grove.Conditions
{
	[Serializable]
	public class Include : ConditionBase
	{
		[SerializeField]
		protected ConditionInput m_Include;

		protected sealed override bool DoEvaluate(IContext context)
		{
			return m_Include.Get(context).Evaluate(context);
		}
	}
}
