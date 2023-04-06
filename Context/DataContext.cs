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
        }

        public DbSet<OrcamentoModel> Orcamentos { get; set; }
        public DbSet<PessoaModel> Pessoas { get; set; }
    }
}
