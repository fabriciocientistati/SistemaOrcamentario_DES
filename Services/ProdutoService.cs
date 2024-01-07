using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Models;

namespace SistemaOrcamentario.Services;

public class ProdutoService : IService<ProdutoModel>
{
    private readonly DataContext _dbcontext;

    public ProdutoService(DataContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    
    public async Task Create(ProdutoModel produto)
    {
        _dbcontext.Add(produto);
        await _dbcontext.SaveChangesAsync();
    }

    public async Task Update(ProdutoModel produto)
    {
        _dbcontext.Update(produto);
        await _dbcontext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var proId = await _dbcontext.TBPRODUTO.FindAsync(id);

        if (proId != null)
        {
            _dbcontext.TBPRODUTO.Remove(proId);
            await _dbcontext.SaveChangesAsync();
        }
    }
    
    public async Task<IEnumerable<ProdutoModel>> FindAll()
    {
        return await _dbcontext.TBPRODUTO.ToListAsync();
    }
}