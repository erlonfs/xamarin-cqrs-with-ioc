using System.Threading.Tasks;

namespace Poc.MobileApp.Shared.Cqrs
{
	public interface IQueryExecutor
	{
		Task<TResult> ExecuteAsync<T, TResult>(T query) where T : IQuery<TResult>;
	}

}
