using Poc.MobileApp.Domain;
using Poc.MobileApp.Domain.Commands;
using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Poc.MobileApp.ViewModels.Pessoa
{
	public partial class CriarViewModel : ViewModel
	{
		private readonly ICommandDispatcher _commandDispatcher;

		public string Nome { get; set; }
		public string Cpf { get; set; }

		public Command Criar { get; set; }

		public CriarViewModel(ICommandDispatcher commandDispatcher)
		{
			_commandDispatcher = commandDispatcher;

			Criar = new Command(CriarCommandAction);

		}

		private async void CriarCommandAction(object obj)
		{
			var pessoaId = Guid.NewGuid();

			try
			{
				var command = new CriarPessoaCommand(pessoaId, Nome, Cpf);
				await _commandDispatcher.DispatchAsync(command);
			}
			catch (BusinessException e)
			{
				BusinessMessage = e.Message;
				base.OnPropertyChanged(nameof(BusinessMessage));
			}
		}

	}
}
