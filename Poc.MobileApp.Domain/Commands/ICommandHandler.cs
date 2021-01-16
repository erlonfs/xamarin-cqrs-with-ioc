using System.Threading.Tasks;

namespace Poc.MobileApp.Domain.Commands
{
	public interface ICommandHandler<in T> where T : ICommand
	{
		Task HandleAsync(T command);
	}
}
