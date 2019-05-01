using System;
using UnityEngine;
using Grove.Actions;
using Grove.Visuals;

namespace Grove.UI
{
	[Serializable]
	public class SetTextColor : ComponentAction<UnityEngine.UI.Text>
	{
		[SerializeField]
		protected ColorInput m_Color;

		protected override void Execute(IActionContext context, UnityEngine.UI.Text text)
		{
			var color = m_Color.Get(context);
			text.color = color;
		}
	}
}
