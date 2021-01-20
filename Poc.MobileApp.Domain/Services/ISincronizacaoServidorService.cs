using Poc.MobileApp.Shared.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poc.MobileApp.Domain.Services
{
	public interface ISincronizacaoServidorService
	{
		Task<IEnumerable<TEntity>> Read<TEntity>(DateTime ultimaSincronizacao) where TEntity : Entity;
		Task Write(IEnumerable<Entity> entity);
	}
}
