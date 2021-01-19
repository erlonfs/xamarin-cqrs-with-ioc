﻿using Microsoft.EntityFrameworkCore;
using Poc.MobileApp.Domain;
using Poc.MobileApp.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poc.MobileApp.Infra.EF.Repositories
{
	public class Repository<TEntity> where TEntity : Entity<Guid>
	{
		private DbSet<TEntity> _dbSet;

		protected Repository(DbContext context)
		{
			_dbSet = context.Set<TEntity>();
		}

		public async Task AddAsync(TEntity entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public async Task<TEntity> GetByEntityIdAsync(Guid entityId)
		{
			var result = _dbSet.Local.SingleOrDefault(x => x.EntityId == entityId);
			if(result == null)
			{
				result = await _dbSet.SingleOrDefaultAsync(x => x.EntityId == entityId);
			}

			return result;

		}

		public Task RemoveAsync(TEntity entity)
		{
			_dbSet.Remove(entity);

			return Task.CompletedTask;
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}
	}
}
