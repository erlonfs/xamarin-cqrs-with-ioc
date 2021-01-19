namespace Poc.MobileApp.Shared.Cqrs
{
	public interface IQueryHandler<in T, out TResult> where T : IQuery<TResult>
	{
		TResult ExecuteAsync(T query);
	}

}
