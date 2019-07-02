using System;
using UnityEngine;
using Grove.Common;
using Grove.Properties;
using Grove.Variables;

namespace Grove.Texts
{
	[Serializable]
	public class SetStringFormat : PropertySetter<string, StringProperty>
	{
		[SerializeField]
		protected StringInput m_Format;
		[SerializeField]
		protected VariableArrayInput m_Args;

		protected override string Evaluate(IContext context)
		{
			var format = m_Format.Get(context);
			var objects = m_Args.LoadObjects(context);

			var result = string.Format(format, objects);

			m_Args.ReleaseObjects(context);
			return result;
		}
	}
}
