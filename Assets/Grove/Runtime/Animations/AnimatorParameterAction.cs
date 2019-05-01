using System;
using UnityEngine;
using Grove.Actions;
using Grove.Texts;

namespace Grove.Animations
{
	[Serializable]
	public abstract class AnimatorParameterAction : ComponentAction<Animator>
	{
		[SerializeField]
		protected StringInput m_Parameter;

		protected sealed override void Execute(IActionContext context, Animator animator)
		{
			var parameter = m_Parameter.Get(context);
			ExecuteParameter(context, animator, parameter);
		}

		protected abstract void ExecuteParameter(IActionContext context, Animator animator, string parameter);
	}
}
