using Poc.MobileApp.Domain;
using Poc.MobileApp.Domain.Commands;
using System;
using Xamarin.Forms;

namespace Poc.MobileApp.ViewModels.Pessoa
{
	public partial class CriarViewModel : ViewModel
	{
		private readonly ICommandDispatcher _commandDispatcher;
		public Command Criar { get; set; }
		public string Nome { get; set; }
		public string Cpf { get; set; }

		public CriarViewModel(ICommandDispatcher commandDispatcher)
		{
			_commandDispatcher = commandDispatcher;
			Criar = new Command(CriarCommandAction);
		}

		private async void CriarCommandAction(object obj)
		{
			try
			{
				var pessoaId = Guid.NewGuid();

				var command = new CriarPessoaCommand(pessoaId, Nome, Cpf);

				await _commandDispatcher.DispatchAsync(command); 
				
				await App.Current.MainPage.DisplayAlert("Sucesso", "Pessoa criada com sucesso", "Ok");


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
