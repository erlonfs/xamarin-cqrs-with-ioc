using Poc.MobileApp.Infra.Dapper;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace Poc.MobileApp.WebApi
{
	public sealed class WebApiAppConnection : AppConnection
	{
		private readonly SqlConnection _sqliteConnection;

		public WebApiAppConnection(SqlConnection sqliteConnection)
		{
			_sqliteConnection = sqliteConnection;
		}
		public override DbConnection GetDBConnection()
		{
			return _sqliteConnection;
		}
	}
}
