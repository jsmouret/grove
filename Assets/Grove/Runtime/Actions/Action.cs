using System;
using UnityEngine;
using Grove.Common;
using Grove.Maths;

namespace Grove.Actions
{
	public interface IAction
	{
		void Execute(IContext context);
	}

	public abstract class ActionBase : IAction
	{
		[SerializeField]
		protected BoolInput m_Disable;

		public void Execute(IContext context)
		{
			if (!m_Disable.Get(context))
			{
				DoExecute(context);
			}
		}

		protected abstract void DoExecute(IContext context);
	}

	[Serializable]
	public sealed class Action : ReorderableArray<ActionVariant>, IAction
	{
		public void Execute(IContext context)
		{
			foreach (var item in m_Items)
			{
				item.Value?.Execute(context);
			}
		}
	}
}