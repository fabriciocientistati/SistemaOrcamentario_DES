using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaOrcamentario.Models;

namespace SistemaOrcamentario.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.ToTable("TBUSUARIO");

            builder.HasKey(u => u.UsuId);

            builder.Property(u => u.UsuNome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(u => u.UsuLogin)
                .HasColumnType("varchar(80)")
                .IsRequired();

            builder.Property(u => u.UsuEmail)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(u => u.UsuSenha)
                .HasColumnType("varchar(40)")
                .IsRequired();
        }
    }
}
