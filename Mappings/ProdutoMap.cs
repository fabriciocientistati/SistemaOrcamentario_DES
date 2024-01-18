using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaOrcamentario.Models;

namespace SistemaOrcamentario.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.ToTable("TBPRODUTO");

            builder.HasOne(p => p.Categoria)
                .WithMany(c => c.CategoriaProdutos)
                .HasForeignKey(p => p.CatId);

            builder.HasIndex(p => p.ProNome).IsUnique();
        }
    }
}
