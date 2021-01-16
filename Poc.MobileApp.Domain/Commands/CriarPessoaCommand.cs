using System;

namespace Poc.MobileApp.Domain.Commands
{
	public class CriarPessoaCommand : ICommand
	{
		public string Nome { get; }
		public string Cpf { get; }
		public DateTime DataCriacao { get; }

		public CriarPessoaCommand(string nome, string cpf)
		{
			if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));
			if (string.IsNullOrWhiteSpace(cpf)) throw new ArgumentNullException(nameof(cpf));

			Nome = nome;
			Cpf = cpf;
		}
	}
}
