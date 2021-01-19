using Autofac;
using Poc.MobileApp.Shared.Cqrs;
using System;
using System.Threading.Tasks;

namespace Poc.MobileApp
{
	public class QueryExecutor : IQueryExecutor
	{
		private readonly IComponentContext _context;

		public QueryExecutor(IComponentContext context)
		{
			_context = context;
		}

		public Task<TResult> ExecuteAsync<T, TResult>(T query) where T : IQuery<TResult>
		{
			if (query == null)
			{
				throw new ArgumentNullException(nameof(query), "Query can not be null.");
			}

			var executor = _context.Resolve<IQueryHandler<T, TResult>>();

			return Task.FromResult(executor.ExecuteAsync(query));

		}
	}

}
