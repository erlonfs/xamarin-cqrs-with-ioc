using Microsoft.EntityFrameworkCore;
using Poc.MobileApp.Domain;
using System.Linq;

namespace Poc.MobileApp.Infra.EF
{
	public class AppDbContext : DbContext
	{
		public DbSet<Pessoa> Pessoa { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			AddMappingsDynamically(modelBuilder);

		}

		private void AddMappingsDynamically(ModelBuilder modelBuilder)
		{
			var currentAssembly = typeof(AppDbContext).Assembly;
			var mappings = currentAssembly.GetTypes().Where(t => t.FullName.StartsWith("Poc.MobileApp.Infra.EF.Mappings") && t.FullName.EndsWith("Map"));

			modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);
		}
	}
}