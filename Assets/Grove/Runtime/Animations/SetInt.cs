using System;
using UnityEngine;
using Grove.Actions;
using Grove.Maths;

namespace Grove.Animations
{
	[Serializable]
	public class SetInt : AnimatorParameterAction
	{
		[SerializeField]
		protected IntInput m_Value;

		protected sealed override void ExecuteParameter(IActionContext context, Animator animator, string parameter)
		{
			var value = m_Value.Get(context);
			animator.SetInteger(parameter, value);
		}
	}
}
