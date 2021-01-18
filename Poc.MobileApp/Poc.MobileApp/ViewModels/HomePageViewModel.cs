using Poc.MobileApp.ViewModels.Pessoa;
using System.Windows.Input;
using Xamarin.Forms;

namespace Poc.MobileApp.ViewModels
{
	public class HomePageViewModel : BaseViewModel
	{

		private readonly INavigator _navigator;

		public HomePageViewModel(INavigator navigator)
		{
			_navigator = navigator;
		}

		public ICommand IrParaConsultar => new Command(() =>
		{
			_navigator.PushAsync<ConsultarViewModel>();
		});

		public ICommand IrParaCriar => new Command(() =>
		{
			_navigator.PushAsync<CriarViewModel>();
		});
	}
}
