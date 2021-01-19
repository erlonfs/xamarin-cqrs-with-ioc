using System.Threading.Tasks;

namespace Poc.MobileApp.Shared.Cqrs
{
	public interface ICommandDispatcher
	{
		Task DispatchAsync<T>(T command) where T : ICommand;
	}
}
