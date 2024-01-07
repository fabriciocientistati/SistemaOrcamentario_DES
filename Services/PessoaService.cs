using Microsoft.EntityFrameworkCore;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaOrcamentario.Services
{
    public class PessoaService : IService<PessoaModel>
    {
        private readonly DataContext _dbContext;

        public PessoaService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(PessoaModel pessoa)
        {
            _dbContext.Add(pessoa);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(PessoaModel pessoa)
        {
            _dbContext.Update(pessoa);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var pesId = await _dbContext.TBPESSOA.FindAsync(id);

            if (pesId != null)
            {
                _dbContext.TBPESSOA.Remove(pesId);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PessoaModel>> FindAll()
        {
            return await _dbContext.TBPESSOA.Include(p => p.Orcamentos).ToListAsync();
        }
    }
}
