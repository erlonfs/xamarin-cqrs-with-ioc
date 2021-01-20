using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poc.MobileApp.Domain;

namespace Poc.MobileApp.Infra.EF.Mappings
{
	public class SincronizacaoMap : IEntityTypeConfiguration<Sincronizacao>
	{
		public void Configure(EntityTypeBuilder<Sincronizacao> builder)
		{
			builder.ToTable("Sincronizacao");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();
			builder.Property(x => x.DataExecucao);
			builder.Property(x => x.Sucesso);

		}
	}
}
