using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaOrcamentario.Models;

namespace SistemaOrcamentario.Mappings
{
    public class PessoaMap : IEntityTypeConfiguration<PessoaModel>
    {
        public void Configure(EntityTypeBuilder<PessoaModel> builder)
        {
            builder.ToTable("TBPESSOA");

            builder.HasKey(p => p.PesId);

            builder.Property(p => p.PesNome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.PesCpf)
                .HasColumnType("varchar(40)")
                .IsRequired();

            builder.Property(p => p.PesCnpj)
                .HasColumnType("varchar(40)");

            builder.Property(p => p.PesNumCelular)
                .HasColumnType("varchar(40)")
                .IsRequired();

            builder.Property(p => p.PesNumTelefone)
                .HasColumnType("varchar(40)");

            builder.Property(p => p.PesEmail)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.PesCep)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(p => p.PesRua)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.PesNumero)
                .HasColumnType("varchar(5)");

            builder.Property(p => p.PesBairro)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.PesCidade)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.PesEstado)
                .HasColumnType("char(2)")
                .IsRequired();

            builder.Property(p => p.PesIncEm)
                .HasColumnType("datetime");
        }
    }
}
