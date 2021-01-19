using Poc.MobileApp.Shared.Data;
using System;

namespace Poc.MobileApp.Domain
{
	public class Pessoa : Entity<Guid>
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Cpf { get; set; }
		public DateTime DataCriacao { get; set; }

		public Pessoa()
		{

		}
	}
}
