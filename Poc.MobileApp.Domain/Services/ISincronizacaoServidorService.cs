using Poc.MobileApp.Shared.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poc.MobileApp.Domain.Services
{
	public interface ISincronizacaoServidorService
	{
		Task<IEnumerable<Entity>> Read(DateTime ultimaSincronizacao);
		Task Write(IEnumerable<Entity> entity);
	}
}
