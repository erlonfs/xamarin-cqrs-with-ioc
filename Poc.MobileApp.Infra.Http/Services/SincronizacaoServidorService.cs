using Poc.MobileApp.Domain;
using Poc.MobileApp.Domain.Services;
using Poc.MobileApp.Shared.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poc.MobileApp.Infra.Http.Services
{
	public class SincronizacaoServidorService : ISincronizacaoServidorService
	{
		public Task<IEnumerable<Entity>> Read(DateTime ultimaSincronizacao)
		{
			var pessoasNaoSincronizadas = new List<Entity>();

			pessoasNaoSincronizadas.Add(new Pessoa
			{
				Cpf = "03443703135",
				DataAlteracao = DateTime.Now,
				DataCriacao = DateTime.Now,
				EntityId = Guid.NewGuid(),
				Nome = "Erlon"
			});

			pessoasNaoSincronizadas.Add(new Pessoa
			{
				Cpf = "02587936145",
				DataAlteracao = DateTime.Now,
				DataCriacao = DateTime.Now,
				EntityId = Guid.NewGuid(),
				Nome = "Joao"
			});

			pessoasNaoSincronizadas.Add(new Pessoa
			{
				Cpf = "01478925800",
				DataAlteracao = DateTime.Now,
				DataCriacao = DateTime.Now,
				EntityId = Guid.NewGuid(),
				Nome = "Paulo"
			});

			return Task.FromResult<IEnumerable<Entity>>(pessoasNaoSincronizadas);
		}

		public Task Write(IEnumerable<Entity> entity)
		{
			return Task.CompletedTask;
		}
	}
}
