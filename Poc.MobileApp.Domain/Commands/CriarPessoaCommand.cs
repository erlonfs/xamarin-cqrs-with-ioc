using System;

namespace Poc.MobileApp.Domain.Commands
{
	public class CriarPessoaCommand : ICommand
	{
		public Guid EntityId { get; }
		public string Nome { get; }
		public string Cpf { get; }
		public DateTime DataCriacao { get; }

		public CriarPessoaCommand(Guid entityId, string nome, string cpf)
		{
			if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));
			if (string.IsNullOrWhiteSpace(cpf)) throw new ArgumentNullException(nameof(cpf));

			EntityId = entityId;
			Nome = nome;
			Cpf = cpf;
			DataCriacao = DateTime.Now;
		}
	}
}
