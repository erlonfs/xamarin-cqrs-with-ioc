using System.Threading.Tasks;

namespace Poc.MobileApp
{
	public interface IUnitOfWork
	{
		Task CommitAsync();
		Task RollBackAsync();
	}
}
