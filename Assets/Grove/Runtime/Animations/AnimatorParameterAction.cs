using System;
using UnityEngine;
using Grove.Actions;
using Grove.Common;
using Grove.Texts;

namespace Grove.Animations
{
	[Serializable]
	public abstract class AnimatorParameterAction : ComponentAction<Animator>
	{
		[SerializeField]
		protected StringInput m_Parameter;

		protected sealed override void Execute(IContext context, Animator animator)
		{
			var parameter = m_Parameter.Get(context);
			ExecuteParameter(context, animator, parameter);
		}

		protected abstract void ExecuteParameter(IContext context, Animator animator, string parameter);
	}
}
