using System;
using UnityEngine;
using Grove.Variables;

namespace Grove.Actions
{
	[Serializable]
	public class ActionOutput : OutputClass<Action>, IAction
	{
		public void Execute(IActionContext context)
		{
			Get().Execute(context);
		}
	}

	[CreateAssetMenu(fileName = "C_Action", menuName = "Grove/Actions/Action Constant", order = 42)]
	public class ActionConstant : Constant<Action, ActionConstant>, IAction
	{
		public void Execute(IActionContext context)
		{
			Get().Execute(context);
		}
	}
}
