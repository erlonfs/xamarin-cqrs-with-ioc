using System.Threading.Tasks;

namespace Poc.MobileApp.Shared.Cqrs
{
	public interface ICommandHandler<in T> where T : ICommand
	{
		Task HandleAsync(T command);
	}
}
