using System;
using UnityEngine;
using Grove.Actions;

namespace Grove.Animations
{
	[Serializable]
	public class SetTrigger : AnimatorParameterAction
	{
		protected sealed override void ExecuteParameter(IActionContext context, Animator animator, string parameter)
		{
			animator.SetTrigger(parameter);
		}
	}
}