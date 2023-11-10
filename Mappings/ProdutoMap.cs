using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaOrcamentario.Models;

namespace SistemaOrcamentario.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.HasKey(p => p.ProdutoId);

            builder.HasMany(p => p.ProdutoOrcamento)
                .WithOne(o => o.Produto)
                .HasForeignKey(o => o.ProdutoId);
        }
    }
}
