using System;
using UnityEngine;

namespace Grove.Actions
{
	[Serializable]
	public class Include : ActionBase
	{
		[SerializeField]
		protected ActionInput m_Include;

		protected sealed override void DoExecute(IActionContext context)
		{
			m_Include.Get(context).Execute(context);
		}
	}
}
