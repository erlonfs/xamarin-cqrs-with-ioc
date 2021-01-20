using Poc.MobileApp.Shared.Data;

namespace Poc.MobileApp.Domain
{
	public class Pessoa : Entity
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Cpf { get; set; }

		public Pessoa()
		{

		}
	}
}
