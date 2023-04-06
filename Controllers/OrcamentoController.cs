using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Models;

namespace SistemaOrcamentario.Controllers
{
    public class OrcamentoController : Controller
    {
        private readonly DataContext _context;

        public OrcamentoController(DataContext context)
        {
            _context = context;
        }

        // GET: Orcamento
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Orcamentos.Include(o => o.Pessoa);
            return View(await dataContext.ToListAsync());
        }

        // GET: Orcamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orcamentos == null)
            {
                return NotFound();
            }

            var orcamentoModel = await _context.Orcamentos
                .Include(o => o.Pessoa)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (orcamentoModel == null)
            {
                return NotFound();
            }

            return View(orcamentoModel);
        }

        // GET: Orcamento/Create
        public IActionResult Create()
        {
            ViewData["PessoaID"] = new SelectList(_context.Pessoas, "ID", "Nome");
            return View();
        }

        // POST: Orcamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PessoaID,Descricao,Observacoes,Preco,TipoPagamento,TipoEntrega,DataInclusao")] OrcamentoModel orcamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orcamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaID"] = new SelectList(_context.Pessoas, "ID", "Nome", orcamento.PessoaID);
            return View(orcamento);
        }

        // GET: Orcamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orcamentos == null)
            {
                return NotFound();
            }

            var orcamentoModel = await _context.Orcamentos.FindAsync(id);
            if (orcamentoModel == null)
            {
                return NotFound();
            }
            ViewData["PessoaID"] = new SelectList(_context.Pessoas, "ID", "Nome", orcamentoModel.PessoaID);
            return View(orcamentoModel);
        }

        // POST: Orcamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PessoaID,Descricao,Observacoes,Preco,TipoPagamento,TipoEntrega,DataInclusao")] OrcamentoModel orcamentoModel)
        {
            if (id != orcamentoModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orcamentoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrcamentoModelExists(orcamentoModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaID"] = new SelectList(_context.Pessoas, "ID", "Nome", orcamentoModel.PessoaID);
            return View(orcamentoModel);
        }

        // GET: Orcamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orcamentos == null)
            {
                return NotFound();
            }

            var orcamentoModel = await _context.Orcamentos
                .Include(o => o.Pessoa)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (orcamentoModel == null)
            {
                return NotFound();
            }

            return View(orcamentoModel);
        }

        // POST: Orcamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orcamentos == null)
            {
                return Problem("Entity set 'DataContext.Orcamentos'  is null.");
            }
            var orcamentoModel = await _context.Orcamentos.FindAsync(id);
            if (orcamentoModel != null)
            {
                _context.Orcamentos.Remove(orcamentoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrcamentoModelExists(int id)
        {
          return _context.Orcamentos.Any(e => e.ID == id);
        }
    }
}
