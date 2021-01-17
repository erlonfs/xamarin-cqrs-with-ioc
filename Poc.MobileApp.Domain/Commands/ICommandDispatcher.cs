using System.Threading.Tasks;

namespace Poc.MobileApp.Domain.Commands
{
	public interface ICommandDispatcher
	{
		Task DispatchAsync<T>(T command) where T : ICommand;
	}
}
