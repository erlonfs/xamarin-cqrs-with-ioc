using Poc.MobileApp.Core.Services;
using Poc.MobileApp.Shared.Common;
using Poc.MobileApp.ViewModels.Pessoa;
using System.Windows.Input;
using Xamarin.Forms;

namespace Poc.MobileApp.ViewModels
{
	public class HomePageViewModel : BaseViewModel
	{

		private readonly INavigator _navigator;
		private readonly ISincronizacaoClienteService _sincronizacaoClienteService;
		private readonly IUnitOfWork _unitOfWork;

		public HomePageViewModel(INavigator navigator, ISincronizacaoClienteService sincronizacaoClienteService, IUnitOfWork unitOfWork)
		{
			_navigator = navigator;
			_sincronizacaoClienteService = sincronizacaoClienteService;
			_unitOfWork = unitOfWork;
		}

		public ICommand IrParaConsultar => new Command(() =>
		{
			_navigator.PushAsync<ConsultarViewModel>();
		});

		public ICommand IrParaCriar => new Command(() =>
		{
			_navigator.PushAsync<CriarViewModel>();
		});

		public ICommand Sincronizar => new Command(async () =>
		{
			await ExecuteWithSafety(async () => {

				await _sincronizacaoClienteService.Sync();

				await _unitOfWork.CommitAsync();

			},

			async () => { await _navigator.PopAsync(); });

		});
	}
}
