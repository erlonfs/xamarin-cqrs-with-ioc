using System.Threading.Tasks;

namespace Poc.MobileApp.Domain.Repositories
{
	public interface IPessoaRepository : IRepository<Pessoa>
	{
		Task<Pessoa> ObterPorCpfAsync(string cpf);
	}
}
