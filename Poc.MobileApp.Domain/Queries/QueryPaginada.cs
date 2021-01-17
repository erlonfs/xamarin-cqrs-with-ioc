using System.Collections.Generic;

namespace Poc.MobileApp.Domain.Queries
{
	public class QueryPaginada<T>
	{
		public IEnumerable<T> Resultado { get; set; }
		public int TotalRegistros { get; set; }
	}

}
