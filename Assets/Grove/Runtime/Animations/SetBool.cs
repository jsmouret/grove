﻿using System;
using UnityEngine;
using Grove.Common;
using Grove.Maths;

namespace Grove.Animations
{
	[Serializable]
	public class SetBool : AnimatorParameterAction
	{
		[SerializeField]
		protected BoolInput m_Not;
		[SerializeField]
		protected BoolInput m_Value;

		protected sealed override void ExecuteParameter(IContext context, Animator animator, string parameter)
		{
			var not = m_Not.Get(context);
			var value = m_Value.Get(context);
			animator.SetBool(parameter, not ^ value);
		}
	}
}
