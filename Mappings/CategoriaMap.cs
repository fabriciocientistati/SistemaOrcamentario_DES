using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaOrcamentario.Models;

namespace SistemaOrcamentario.Mappings;

public class CategoriaMap : IEntityTypeConfiguration<CategoriaModel>
{
    public void Configure(EntityTypeBuilder<CategoriaModel> builder)
    {
        builder.ToTable("TBCAREGORIA");

        builder.HasOne(c => c.CategoriaProdutos)
            .WithMany(p => p.)
    }
}