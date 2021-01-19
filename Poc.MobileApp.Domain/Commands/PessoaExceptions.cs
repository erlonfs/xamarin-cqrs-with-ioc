using Poc.MobileApp.Shared.Common;

namespace Poc.MobileApp.Domain.Commands
{
	public class PessoaJaExistenteParaCpfException : BusinessException
	{
		public string Nome { get; }
		public string Cpf { get; }

		public PessoaJaExistenteParaCpfException(string nome, string cpf) : base($"Ja existe uma pessoa com nome de \"{nome}\" para o cpf {cpf}")
		{
			Nome = nome;
			Cpf = cpf;
		}
	}
}
