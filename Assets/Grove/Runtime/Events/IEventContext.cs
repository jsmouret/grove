using Grove.Common;

namespace Grove.Events
{
	public interface IEventContext : IContext
	{
		void OnEvent();
	}
}
