using System;
using UnityEngine;
using Grove.Common;

namespace Grove.Animations
{
	[Serializable]
	public class SetTrigger : AnimatorParameterAction
	{
		protected sealed override void ExecuteParameter(IContext context, Animator animator, string parameter)
		{
			animator.SetTrigger(parameter);
		}
	}
}