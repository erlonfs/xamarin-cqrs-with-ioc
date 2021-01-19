using Poc.MobileApp.Domain.Repositories;
using Poc.MobileApp.Shared.Cqrs;
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
			var pessoaExistentePorCpf = await _pessoaRepository.ObterPorCpfAsync(command.Cpf);
			if (pessoaExistentePorCpf != null) throw new PessoaJaExistenteParaCpfException(pessoaExistentePorCpf.Nome, pessoaExistentePorCpf.Cpf);

			var pessoa = new Pessoa
			{
				EntityId = command.EntityId,
				Nome = command.Nome,
				DataCriacao = command.DataCriacao,
				Cpf = command.Cpf
			};

			await _pessoaRepository.AddAsync(pessoa);
		}
	}
}
