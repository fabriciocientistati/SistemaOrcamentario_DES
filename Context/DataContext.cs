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
            modelBuilder.ApplyConfiguration(new PerfilMap());
        }

        public DbSet<OrcamentoModel> Orcamentos { get; set; }
        public DbSet<PessoaModel> Pessoas { get; set; }

        public DbSet<Models.UsuarioModel> Usuarios { get; set; }
        public DbSet<PerfilModel> Perfils { get; set; }
    }
}
