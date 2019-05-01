﻿using System;
using UnityEngine;

namespace Grove.Actions
{
	[Serializable]
	public abstract class ComponentAction<TComponent> : ActionBase
		where TComponent : class
	{
		[SerializeField]
		protected TComponent m_TargetOverride;

		protected sealed override void DoExecute(IActionContext context)
		{
			if (m_TargetOverride != null)
			{
				Execute(context, m_TargetOverride);
			}
			else
			{
				var behaviour = context.GetBehaviour();
				var target = behaviour.GetComponent<TComponent>();
				if (target != null)
				{
					Execute(context, target);
				}
				else
				{
					Debug.LogAssertion($"Cannot find target {typeof(TComponent)}", behaviour);
				}
			}
		}

		protected abstract void Execute(IActionContext context, TComponent component);
	}
}
