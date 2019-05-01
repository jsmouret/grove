using UnityEngine;
using Grove.Common;

namespace Grove.Variables
{
	public interface IVariable<T>
	{
		T Load(IContext context);
	}

	public abstract class Variable : ScriptableObject, IVariable<object>
	{
		public abstract object Load(IContext context);
	}
}
