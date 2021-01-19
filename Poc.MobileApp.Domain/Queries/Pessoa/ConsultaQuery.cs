using Poc.MobileApp.Shared.Cqrs;
using System;
using System.Collections.Generic;

namespace Poc.MobileApp.Domain.Queries.Pessoa
{
	public class ConsultaQuery : IQuery<IEnumerable<ConsultaDto>>
	{
		public ConsultaQuery()
		{

		}
	}

	public class ConsultaDto
	{
		public string EntityId { get; set; }
		public string Nome { get; set; }
		public string Cpf { get; set; }
		public DateTime DataCriacao { get; set; }
	}
}
