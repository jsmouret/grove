using System;
using UnityEngine;
using Grove.Common;
using Grove.Properties;

namespace Grove.Actions
{
	[Serializable]
	public class ActionInput : AbstractInput<Action, ActionProperty, ActionConstant>, IAction
	{
		public void Execute(IContext context)
		{
			Get(context).Execute(context);
		}
	}

	[CreateAssetMenu(fileName = "MyAction", menuName = "Grove/Actions/Action Property", order = 43)]
	public class ActionProperty : Property<Action>, IAction
	{
		public void Execute(IContext context)
		{
			Load(context).Execute(context);
		}
	}
}
