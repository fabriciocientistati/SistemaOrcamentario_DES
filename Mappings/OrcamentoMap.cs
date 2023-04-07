using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaOrcamentario.Models;

namespace SistemaOrcamentario.Mappings
{
    public class OrcamentoMap : IEntityTypeConfiguration<OrcamentoModel>
    {
        public void Configure(EntityTypeBuilder<OrcamentoModel> builder)
        {
            builder.ToTable("Orcamento");

            builder.Property(p => p.Descricao)
                .HasColumnType("nvarchar(MAX)")
                .IsRequired();

            builder.Property(p => p.Observacoes)
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Preco)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.TipoPagamento)
                .HasColumnType("varchar(80)");

            builder.Property(p => p.TipoEntrega)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.DataInclusao)
                .HasColumnType("datetime");

            builder.HasOne(p => p.Pessoa)
                .WithMany()
                .HasForeignKey(p => p.PessoaID);

            //builder.HasIndex(p => p.ID)
            //    .HasDatabaseName("IX_OrcamentoModel_ID");

            //builder.HasOne(p => p.Pessoa)
            //    .WithMany(p => p.Orcamentos)
            //    .HasForeignKey(p => p.PessoaID)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
