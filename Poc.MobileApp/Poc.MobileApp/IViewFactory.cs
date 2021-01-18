using Xamarin.Forms;

namespace Poc.MobileApp
{
	public interface IViewFactory
	{
		void Register<TViewModel, TView>() where TViewModel : class, IViewModelBase where TView : Page;
		Page Resolve<TViewModel>() where TViewModel : class, IViewModelBase;
	}
}
