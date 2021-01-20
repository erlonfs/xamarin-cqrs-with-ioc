using Microsoft.EntityFrameworkCore;
using Poc.MobileApp.Infra.EF;
using Poc.MobileApp.Shared.Common;
using Poc.MobileApp.Shared.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Poc.MobileApp
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly DbContext _dbContext;

		public UnitOfWork(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task CommitAsync()
		{
			try
			{
				using (var transaction = await _dbContext.Database.BeginTransactionAsync())
				{
					try
					{
						var changedEntries = _dbContext.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();

						foreach (var entry in changedEntries)
						{
							var entity = entry.Entity as Entity<Guid>;

							switch (entry.State)
							{
								case EntityState.Modified:
									entity.DataAlteracao = DateTime.Now;
									break;
								case EntityState.Added:
									entity.DataCriacao = DateTime.Now;
									entity.DataAlteracao = entity.DataCriacao;
									break;
							}
						}

						await _dbContext.SaveChangesAsync();

						transaction.Commit();

					}
					catch (Exception)
					{
						transaction.Rollback();
						throw;
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public Task RollBackAsync()
		{
			try
			{
				var changedEntries = _dbContext.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();

				foreach (var entry in changedEntries)
				{
					switch (entry.State)
					{
						case EntityState.Modified:
							entry.CurrentValues.SetValues(entry.OriginalValues);
							entry.State = EntityState.Unchanged;
							break;
						case EntityState.Added:
							entry.State = EntityState.Detached;
							break;
						case EntityState.Deleted:
							entry.State = EntityState.Unchanged;
							break;
					}
				}
			}
			catch (Exception)
			{
				throw;
			}

			return Task.CompletedTask;

		}
	}
}
