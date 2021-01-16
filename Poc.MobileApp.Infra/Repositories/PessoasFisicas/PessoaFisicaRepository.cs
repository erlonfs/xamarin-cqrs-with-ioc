using Microsoft.EntityFrameworkCore;
using Poc.MobileApp.Domain;
using Poc.MobileApp.Domain.Repositories;
using System.Threading.Tasks;

namespace Poc.MobileApp.Infra.EF.Repositories.PessoasFisicas
{
	public class PessoaFisicaRepository : Repository<Pessoa>,  IPessoaRepository
	{
		private AppDbContext _context;

		public PessoaFisicaRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<Pessoa> ObterPorCpfAsync(string cpf)
		{
			return await _context.Pessoa.FirstOrDefaultAsync(x => x.Cpf == cpf);
		}
	}
}
