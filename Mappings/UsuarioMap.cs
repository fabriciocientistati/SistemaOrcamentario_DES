using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaOrcamentario.Models;

namespace SistemaOrcamentario.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(u => u.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasColumnType("varchar(40)")
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasOne(u => u.Perfil)
                .WithOne(p => p.Usuario)
                .HasForeignKey<PerfilModel>(p => p.UsuarioId);
        }
    }
}
