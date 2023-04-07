using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaOrcamentario.Models;

namespace SistemaOrcamentario.Mappings
{
    public class PessoaMap : IEntityTypeConfiguration<PessoaModel>
    {
        public void Configure(EntityTypeBuilder<PessoaModel> builder)
        {
            builder.ToTable("Pessoa");

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Cpf)
                .HasColumnType("varchar(40)")
                .IsRequired();

            builder.Property(p => p.Cnpj)
                .HasColumnType("varchar(40)");

            builder.Property(p => p.NumberCellPhone)
                .HasColumnType("varchar(40)")
                .IsRequired();

            builder.Property(p => p.NumberFixPhone)
                .HasColumnType("varchar(40)");

            builder.Property(p => p.Email)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Cep)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(p => p.Rua)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Numero)
                .HasColumnType("varchar(5)");

            builder.Property(p => p.Bairro)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Cidade)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Estado)
                .HasColumnType("char(2)")
                .IsRequired();

            builder.Property(p => p.DataInclusao)
                .HasColumnType("datetime");
        }
    }
}
