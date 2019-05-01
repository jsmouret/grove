using System;
using UnityEngine;
using Grove.Actions;
using Grove.Common;
using Grove.Texts;
using Grove.Variables;

namespace Grove.UI
{
	[Serializable]
	public class SetTextFormat : ComponentAction<UnityEngine.UI.Text>
	{
		[SerializeField]
		protected StringInput m_Format;
		[SerializeField]
		protected VariableArrayInput m_Args;

		protected override void Execute(IContext context, UnityEngine.UI.Text text)
		{
			var format = m_Format.Get(context);
			var objects = m_Args.LoadObjects(context);

			text.text = string.Format(format, objects);

			m_Args.ReleaseObjects(context);
		}
	}
}
