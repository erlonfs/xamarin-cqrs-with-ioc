using Poc.MobileApp.Domain;
using Poc.MobileApp.Domain.Commands;
using System;
using Xamarin.Forms;

namespace Poc.MobileApp.ViewModels.Pessoa
{

	public partial class CriarViewModel : BaseViewModel
	{
		private readonly ICommandDispatcher _commandDispatcher;
		private readonly IUnitOfWork _unitOfWork;
		private readonly INavigator _navigator;

		public Command Criar { get; set; }
		public string Nome { get; set; }
		public string Cpf { get; set; }

		public CriarViewModel(ICommandDispatcher commandDispatcher, IUnitOfWork unitOfWork, INavigator navigator)
		{
			_commandDispatcher = commandDispatcher;
			_unitOfWork = unitOfWork;
			_navigator = navigator;

			Criar = new Command(CriarCommandAction);
		}

		private async void CriarCommandAction(object obj)
		{
			try
			{
				var pessoaId = Guid.NewGuid();

				var command = new CriarPessoaCommand(pessoaId, Nome, Cpf);

				await _commandDispatcher.DispatchAsync(command);

				await _unitOfWork.CommitAsync();

				await App.Current.MainPage.DisplayAlert("Sucesso", "Pessoa criada com sucesso", "Ok");

				await _navigator.PopAsync();


			}
			catch (BusinessException e)
			{
				await App.Current.MainPage.DisplayAlert("Verifique", e.Message, "Ok");
			}
			catch (Exception e)
			{
				await App.Current.MainPage.DisplayAlert("Ocorreu um erro", e.Message, "Ok");
			}
		}

	}
}
