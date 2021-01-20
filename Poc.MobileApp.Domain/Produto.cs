using Poc.MobileApp.Shared.Data;

namespace Poc.MobileApp.Domain
{
	public class Produto : Entity
	{
		public string Nome { get; }
		public string Descricao { get; }

		public Produto(string nome, string descricao)
		{
			Nome = nome;
			Descricao = descricao;
		}
	}
}
