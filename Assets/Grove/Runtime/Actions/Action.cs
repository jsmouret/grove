using System;
using UnityEngine;
using Grove.Common;
using Grove.Maths;

namespace Grove.Actions
{
	public interface IActionContext : IContext
	{
		MonoBehaviour GetBehaviour();
	}

	public interface IAction
	{
		void Execute(IActionContext context);
	}

	public abstract class ActionBase : IAction
	{
		[SerializeField]
		protected BoolInput m_Disable;

		public void Execute(IActionContext context)
		{
			if (!m_Disable.Get(context))
			{
				DoExecute(context);
			}
		}

		protected abstract void DoExecute(IActionContext context);
	}

	[Serializable]
	public sealed class Action : ReorderableArray<ActionVariant>, IAction
	{
		public void Execute(IActionContext context)
		{
			foreach (var item in m_Items)
			{
				item.Value?.Execute(context);
			}
		}
	}
}