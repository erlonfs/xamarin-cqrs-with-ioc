using Microsoft.Data.Sqlite;
using Poc.MobileApp.Infra.Dapper;
using System.Data.Common;

namespace Poc.MobileApp
{
	public sealed class MobileAppConnection : AppConnection
	{
		private readonly SqliteConnection _sqliteConnection;

		public MobileAppConnection(SqliteConnection sqliteConnection)
		{
			_sqliteConnection = sqliteConnection;
		}
		public override DbConnection GetDBConnection()
		{
			return _sqliteConnection;
		}
	}
}
