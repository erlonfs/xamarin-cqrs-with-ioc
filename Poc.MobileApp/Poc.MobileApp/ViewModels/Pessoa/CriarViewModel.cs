using Poc.MobileApp.Domain.Commands;
using Poc.MobileApp.Shared.Common;
using Poc.MobileApp.Shared.Cqrs;
using System;
using Xamarin.Forms;

namespace Poc.MobileApp.ViewModels.Pessoa
{

	public partial class CriarViewModel : BaseViewModel
	{
		private readonly ICommandDispatcher _commandDispatcher;
		private readonly IUnitOfWork _unitOfWork;
		private readonly INavigator _navigator;

		public string Nome { get; set; }
		public string Cpf { get; set; }

		public CriarViewModel(ICommandDispatcher commandDispatcher, IUnitOfWork unitOfWork, INavigator navigator)
		{
			_commandDispatcher = commandDispatcher;
			_unitOfWork = unitOfWork;
			_navigator = navigator;
		}


		public Command Criar => new Command(async () =>
		{
			await ExecuteWithSafety(async () =>
			{
				var pessoaId = Guid.NewGuid();
				var command = new CriarPessoaCommand(pessoaId, Nome, Cpf);

				await _commandDispatcher.DispatchAsync(command);
				await _unitOfWork.CommitAsync();

			}, 

			async () => { await _navigator.PopAsync(); });

		});

	}
}
