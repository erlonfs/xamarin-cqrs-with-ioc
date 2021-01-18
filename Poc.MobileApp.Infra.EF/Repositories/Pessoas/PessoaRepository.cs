using Microsoft.EntityFrameworkCore;
using Poc.MobileApp.Domain;
using Poc.MobileApp.Domain.Repositories;
using System.Threading.Tasks;

namespace Poc.MobileApp.Infra.EF.Repositories.Pessoas
{
	public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
	{
		private AppDbContext _context;

		public PessoaRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<Pessoa> ObterPorCpfAsync(string cpf)
		{
			return await _context.Pessoa.FirstOrDefaultAsync(x => x.Cpf == cpf);
		}
	}
}
