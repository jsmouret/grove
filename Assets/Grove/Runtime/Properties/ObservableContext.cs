using Grove.Common;
using Grove.Variables;

namespace Grove.Properties
{
	public interface IObservableContext
	{
		bool IsChanging(IContext context);
		void Subscribe(IContext context, Callback callback);
		void Unsubscribe(IContext context, Callback callback);
	}
}
