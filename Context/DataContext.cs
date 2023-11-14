using Microsoft.EntityFrameworkCore;
using SistemaOrcamentario.Mappings;
using SistemaOrcamentario.Models;

namespace SistemaOrcamentario.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options) { }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new OrcamentoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            //modelBuilder.ApplyConfiguration(new ProdutoMap());
            //modelBuilder.ApplyConfiguration(new CategoriaMap());
            //modelBuilder.ApplyConfiguration(new ProdutoOrcamentoMap());
        }

        //public DbSet<ProdutoOrcamento> TBPRODUTOORCAMENTO { get; set; }
        //public DbSet<ProdutoModel> TBPRODUTO { get; set; }
        public DbSet<OrcamentoModel> TBORCAMENTO { get; set; }
        public DbSet<PessoaModel> TBPESSOA { get; set; }
        public DbSet<UsuarioModel> TBUSUARIO { get; set; }
        //public DbSet<CategoriaModel> TBCATEGORIA { get; set; }
    }
}
