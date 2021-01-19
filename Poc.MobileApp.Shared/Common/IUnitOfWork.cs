using System.Threading.Tasks;

namespace Poc.MobileApp.Shared.Common
{
	public interface IUnitOfWork
	{
		Task CommitAsync();
		Task RollBackAsync();
	}
}
