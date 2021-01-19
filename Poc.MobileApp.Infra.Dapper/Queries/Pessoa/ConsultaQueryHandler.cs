using Dapper;
using Poc.MobileApp.Domain.Queries.Pessoa;
using Poc.MobileApp.Shared.Cqrs;
using System.Collections.Generic;

namespace Poc.MobileApp.Infra.Dapper.Queries.Pessoa
{
	public partial class ConsultaQueryHandler : IQueryHandler<ConsultaQuery, IEnumerable<ConsultaDto>>
	{
		private readonly AppConnection _appConnection;

		public ConsultaQueryHandler(AppConnection appConnection)
		{
			_appConnection = appConnection;
		}

		public IEnumerable<ConsultaDto> ExecuteAsync(ConsultaQuery query)
		{
			var sql = @"SELECT Nome, Cpf, DataCriacao FROM Pessoa";

			using (var conn = _appConnection.GetDBConnection())
			{
				return conn.Query<ConsultaDto>(sql);
			}
		}
	}
}
