using Poc.MobileApp.Domain.Repositories;
using System.Threading.Tasks;

namespace Poc.MobileApp.Domain.Commands
{
	public class CriarPessoaCommandHandler : ICommandHandler<CriarPessoaCommand>
	{
		private readonly IPessoaRepository _pessoaRepository;

		public CriarPessoaCommandHandler(IPessoaRepository pessoaRepository)
		{
			_pessoaRepository = pessoaRepository;
		}

		public async Task HandleAsync(CriarPessoaCommand command)
		{
			var pessoa = new Pessoa
			{
				Nome = command.Nome,
				DataCriacao = command.DataCriacao,
			};

			await _pessoaRepository.AddAsync(pessoa);

		}
	}
}
