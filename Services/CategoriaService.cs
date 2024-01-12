using Microsoft.EntityFrameworkCore;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaOrcamentario.Services
{
    public class CategoriaService : IService<CategoriaModel>
    {
        private readonly DataContext _dbContext;

        public CategoriaService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(CategoriaModel categoria)
        {
            _dbContext.Add(categoria);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(CategoriaModel categoria)
        {
            _dbContext.Update(categoria);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var catId = await _dbContext.TBCATEGORIA.FindAsync(id);

            if (catId != null)
            {
                _dbContext.TBCATEGORIA.Remove(catId);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CategoriaModel>>FindAll()
        {
            return await _dbContext.TBCATEGORIA.ToListAsync();
        }
    }
}
