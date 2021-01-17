using System.Threading.Tasks;

namespace Poc.MobileApp.Domain.Queries
{
	public interface IQueryExecutor
	{
		Task<TResult> ExecuteAsync<T, TResult>(T query) where T : IQuery<TResult>;
	}

}
