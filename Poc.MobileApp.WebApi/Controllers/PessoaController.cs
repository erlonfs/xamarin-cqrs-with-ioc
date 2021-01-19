using Microsoft.AspNetCore.Mvc;
using Poc.MobileApp.Domain.Commands;
using Poc.MobileApp.Domain.Queries.Pessoa;
using Poc.MobileApp.Shared.Common;
using Poc.MobileApp.Shared.Cqrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poc.MobileApp.WebApi.Controllers
{

	[Produces("application/json")]
	[Route("api/pessoas")]
	public class PessoaController : BaseApiController
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICommandDispatcher _commandDispatcher;
		private readonly IQueryExecutor _queryExecutor;

		public PessoaController(IUnitOfWork unitOfWork,
								ICommandDispatcher commandDispatcher,
								IQueryExecutor queryExecutor)
		{
			_unitOfWork = unitOfWork;
			_commandDispatcher = commandDispatcher;
			_queryExecutor = queryExecutor;
		}

		[HttpPost]
		[Route("")]
		public async Task<Guid> CriarAsync(string nome, string cpf)
		{
			var pessoaId = Guid.NewGuid();
			var command = new CriarPessoaCommand(pessoaId, nome, cpf);

			await _commandDispatcher.DispatchAsync(command);

			await _unitOfWork.CommitAsync();

			return pessoaId;

		}

		[HttpGet]
		[Route("")]
		public async Task<IEnumerable<ConsultaDto>> ObterAsync()
		{
			var query = new ConsultaQuery();
			var result = await _queryExecutor.ExecuteAsync<ConsultaQuery, IEnumerable<ConsultaDto>>(query);

			if (result == null || !result.Any()) NotFound();

			return result;

		}
	}
}
