using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Models;

namespace SistemaOrcamentario.Services;

public class OrcamentoService : IService<OrcamentoModel>
{
    private readonly DataContext _db;

    public OrcamentoService(DataContext db)
    {
        _db = db;
    }

    public async Task Create(OrcamentoModel orcamento)
    {
        _db.Add(orcamento);
        await _db.SaveChangesAsync();
    }

    public async Task Update(OrcamentoModel orcamento)
    {
        _db.Update(orcamento);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var orcId = await _db.TBORCAMENTO.FindAsync(id);

        if (orcId != null)
        {
            _db.TBORCAMENTO.Remove(orcId);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<OrcamentoModel>> FindAll()
    {
        return await _db.TBORCAMENTO.ToListAsync();
    }
}