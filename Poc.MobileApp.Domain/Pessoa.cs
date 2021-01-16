using System;

namespace Poc.MobileApp.Domain
{
	public class Pessoa
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
