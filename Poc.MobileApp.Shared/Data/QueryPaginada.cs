using System.Collections.Generic;

namespace Poc.MobileApp.Shared.Data
{
	public class QueryPaginada<T>
	{
		public IEnumerable<T> Resultado { get; set; }
		public int TotalRegistros { get; set; }
	}

}
