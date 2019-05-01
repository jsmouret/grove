using Grove.Common;
using Grove.Variables;

namespace Grove.Properties
{
	public interface IObservableContext
	{
		IObservable GetObservable(IContext context);
	}
}
