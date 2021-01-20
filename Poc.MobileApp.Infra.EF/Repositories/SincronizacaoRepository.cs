using Microsoft.EntityFrameworkCore;
using Poc.MobileApp.Domain;
using Poc.MobileApp.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Poc.MobileApp.Infra.EF.Repositories.Pessoas
{
	public class SincronizacaoRepository : ISincronizacaoRepository
	{
		private AppDbContext _context;

		public SincronizacaoRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Sincronizacao sincronizacao)
		{
			await _context.AddAsync(sincronizacao);
		}

		public async Task<Sincronizacao> ObterUltimaAsync()
		{
			return await _context.Sincronizacao.OrderByDescending(x => x.DataExecucao).FirstOrDefaultAsync();
		}
	}
}
