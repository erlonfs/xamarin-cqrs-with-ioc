using System.Threading.Tasks;

namespace Poc.MobileApp.Domain.Repositories
{
	public interface ISincronizacaoRepository
	{
		Task AddAsync(Sincronizacao sincronizacao);
		Task<Sincronizacao> ObterUltimaAsync();
	}
}
