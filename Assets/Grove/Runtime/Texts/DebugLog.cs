using System;
using UnityEngine;
using Grove.Actions;
using Grove.Variables;

namespace Grove.Texts
{
	[Serializable]
	public class DebugLog : ActionBase
	{
		protected enum Severity
		{
			Info,
			Warning,
			Error,
			Assert,
		}

		[SerializeField]
		protected Severity m_Severity;
		[SerializeField]
		protected StringInput m_Format;
		[SerializeField]
		protected VariableArrayInput m_Args;

		protected override void DoExecute(IActionContext context)
		{
			var behaviour = context.GetBehaviour();
			var format = m_Format.Get(context);
			var objects = m_Args.LoadObjects(context);

			switch (m_Severity)
			{
				case Severity.Info:
					Debug.LogFormat(behaviour, format, objects);
					break;
				case Severity.Warning:
					Debug.LogWarningFormat(behaviour, format, objects);
					break;
				case Severity.Error:
					Debug.LogErrorFormat(behaviour, format, objects);
					break;
				case Severity.Assert:
					Debug.LogAssertionFormat(behaviour, format, objects);
					break;
				default:
					Debug.LogAssertion($"Unknown Severity {m_Severity}");
					break;
			}

			m_Args.ReleaseObjects(context);
		}
	}
}
