using Poc.MobileApp.Core.Services;
using Poc.MobileApp.Domain;
using Poc.MobileApp.Domain.Repositories;
using Poc.MobileApp.Domain.Services;
using System;
using System.Threading.Tasks;

namespace Poc.MobileApp.Infra.EF.Services
{
	public class SincronizacaoClienteService : ISincronizacaoClienteService
	{
		private readonly ISincronizacaoRepository _sincronizacaoRepository;
		private readonly IPessoaRepository _pessoaRepository;
		private readonly ISincronizacaoServidorService _sincronizacaoServidorService;

		public SincronizacaoClienteService(ISincronizacaoRepository sincronizacaoRepository,
											IPessoaRepository pessoaRepository,
											ISincronizacaoServidorService sincronizacaoServidorService)
		{
			_sincronizacaoRepository = sincronizacaoRepository;
			_pessoaRepository = pessoaRepository;
			_sincronizacaoServidorService = sincronizacaoServidorService;
		}

		public async Task Sync()
		{
			var ultimaSincronizacao = await _sincronizacaoRepository.ObterUltimaAsync();

			var dataUltimaSincronizacao = ultimaSincronizacao?.DataExecucao ?? DateTime.MinValue;

			var pessoas = await _pessoaRepository.GetAllAfterDateAsync(dataUltimaSincronizacao);

			await _sincronizacaoServidorService.Write(pessoas);

			var dataInicio = DateTime.Now;

			var itensNaoSincronizadosDoServer = await _sincronizacaoServidorService.Read<Pessoa>(dataUltimaSincronizacao);


			foreach (var entity in itensNaoSincronizadosDoServer)
			{
				await _pessoaRepository.AddAsync(entity as Pessoa);
			}

			await _sincronizacaoRepository.AddAsync(new Sincronizacao
			{
				DataExecucao = dataInicio,
				Sucesso = true

			});


		}
	}
}
