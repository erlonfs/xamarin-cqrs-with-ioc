using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poc.MobileApp.Shared.Data
{
	public interface IRepository<T>
	{
		Task AddAsync(T entity);
		Task RemoveAsync(T entity);
		Task<T> GetByEntityIdAsync(Guid entityId);
		Task<IEnumerable<T>> GetAllAsync();
		Task<IEnumerable<T>> GetAllAfterDateAsync(DateTime date);
	}
}
