using System;
using UnityEngine;
using Grove.Common;

namespace Grove.Variables
{
	public interface IVariableArray
	{
		object[] LoadObjects(IContext context);
		void ReleaseObjects(IContext context);
	}

	[Serializable]
	public class VariableArray : ReorderableArray<Variable>, IVariableArray
	{
		// TODO: improve this if concurrent calls are needed

		private object[] m_Objects;

		public object[] LoadObjects(IContext context)
		{
			int count = m_Items.Length;

			if (m_Objects == null || m_Objects.Length != count)
			{
				m_Objects = new object[count];
			}

			for (int i = 0; i < count; ++i)
			{
				m_Objects[i] = m_Items[i].Load(context);
			}

			return m_Objects;
		}

		public void ReleaseObjects(IContext context)
		{
			for (int i = 0; i < m_Objects.Length; ++i)
			{
				m_Objects[i] = null;
			}
		}
	}
}
