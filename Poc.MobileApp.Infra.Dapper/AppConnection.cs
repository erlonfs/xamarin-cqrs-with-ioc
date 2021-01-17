using System.Data.Common;

namespace Poc.MobileApp.Infra.Dapper
{
	public abstract class AppConnection
	{
		public abstract DbConnection GetDBConnection();
	}
}
