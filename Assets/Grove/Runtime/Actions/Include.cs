using System;
using UnityEngine;
using Grove.Common;

namespace Grove.Actions
{
	[Serializable]
	public class Include : ActionBase
	{
		[SerializeField]
		protected ActionInput m_Include;

		protected sealed override void DoExecute(IContext context)
		{
			m_Include.Get(context).Execute(context);
		}
	}
}
