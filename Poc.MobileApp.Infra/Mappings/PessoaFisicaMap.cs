using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poc.MobileApp.Domain;

namespace Poc.MobileApp.Infra.EF.Mappings
{
	public class PessoaFisicaMap : IEntityTypeConfiguration<Pessoa>
	{
		public void Configure(EntityTypeBuilder<Pessoa> builder)
		{
			builder.ToTable("Pessoa", "dm");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();

			builder.Property(x => x.DataCriacao);
			builder.Property(x => x.Nome);
			builder.Property(x => x.Cpf);
		}
	}
}
