using System;
using UnityEngine;
using Grove.Actions;
using Grove.Maths;

namespace Grove.GameObjects
{
	[Serializable]
	public class SetActive : ActionBase
	{
		[SerializeField]
		protected GameObjectInput m_Target;
		[SerializeField]
		protected BoolInput m_Not;
		[SerializeField]
		protected BoolInput m_Active;

		protected override void DoExecute(IActionContext context)
		{
			var go = m_Target.Get(context);
			var not = m_Not.Get(context);
			var active = m_Active.Get(context);

			go.SetActive(not ^ active);
		}
	}
}
