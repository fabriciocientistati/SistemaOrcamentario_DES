using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaOrcamentario.Models;
using System.Reflection.Emit;

namespace SistemaOrcamentario.Mappings
{
    public class OrcamentoMap : IEntityTypeConfiguration<OrcamentoModel>
    {
        public void Configure(EntityTypeBuilder<OrcamentoModel> builder)
        {
            builder.ToTable("TBORCAMENTO");

            builder.HasKey(o => o.OrcId);

            builder.HasOne(o => o.OrcamentoPessoa)
                .WithMany(p => p.Orcamentos)
                .HasForeignKey(o => o.PesId);

            builder.Property(p => p.OrcDesc)
                .HasColumnType("nvarchar(MAX)")
                .IsRequired();

            builder.Property(p => p.OrcObservacao)
                .HasColumnType("varchar(250)");

            builder.Property(o => o.OrcPreco)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.OrcTipoPagamento)
                .HasColumnType("varchar(80)");

            builder.Property(p => p.OrcTipoEntrega)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.OrcIncEm)
                .HasColumnType("datetime");
        }
    }
}
