using UnityEngine;

namespace Grove.Common
{
	public delegate void ContextAction(IContext context);

	public interface IContext
	{
		MonoBehaviour GetBehaviour();

		void OnEvent();

		void AddOnDestroy(ContextAction onDestroy);
	}
}