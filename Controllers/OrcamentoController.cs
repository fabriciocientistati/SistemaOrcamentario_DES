using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Filters;
using SistemaOrcamentario.Models;

namespace SistemaOrcamentario.Controllers
{
    [PaginaParaUsuarioLogado]
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
            var dataContext = _context.TBORCAMENTO.Include(o => o.OrcamentoPessoa);
            return View(await dataContext.ToListAsync());
        }

        // GET: Orcamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TBORCAMENTO == null)
            {
                return NotFound();
            }

            var orcamentoModel = await _context.TBORCAMENTO
                .Include(o => o.OrcamentoPessoa)
                .FirstOrDefaultAsync(m => m.PesId == id);
            if (orcamentoModel == null)
            {
                return NotFound();
            }

            return View(orcamentoModel);
        }

        // GET: Orcamento/Create
        public IActionResult Create(int? id) //Carrega o ID que vem por parametro
        {
            if (id == null || id == 0)
            {
                ViewData["PesId"] = new SelectList(_context.TBPESSOA, "PesId", "Nome"); //Lista nomes no select aleatório

                return View();
            }
            ViewBag.PessoaID = new SelectList(_context.TBPESSOA, "PesId", "Nome", id); //Lista nome no select por parametro
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("PessoaID,Descricao,Observacoes,Preco,TipoPagamento,TipoEntrega,DataInclusao")] OrcamentoModel orcamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orcamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PesId"] = new SelectList(_context.TBPESSOA, "PesId", "Nome", orcamento.PesId);
            return View(orcamento);
        }

        // GET: Orcamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TBORCAMENTO == null)
            {
                return NotFound();
            }

            var orcamentoModel = await _context.TBORCAMENTO.FindAsync(id);
            if (orcamentoModel == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(_context.TBPESSOA, "OrcamentoId", "Nome", orcamentoModel.PesId);
            return View(orcamentoModel);
        }

        // POST: Orcamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrcamentoId,PessoaId,Descricao,Observacoes,Preco,TipoPagamento,TipoEntrega,DataInclusao")] OrcamentoModel orcamentoModel)
        {
            if (id != orcamentoModel.OrcId)
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
                    if (!OrcamentoModelExists(orcamentoModel.OrcId))
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
            ViewData["PessoaID"] = new SelectList(_context.TBPESSOA, "OrcamentoId", "Nome", orcamentoModel.PesId);
            return View(orcamentoModel);
        }

        // GET: Orcamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TBORCAMENTO == null)
            {
                return NotFound();
            }

            var orcamentoModel = await _context.TBORCAMENTO
                .Include(o => o.OrcamentoPessoa)
                .FirstOrDefaultAsync(m => m.OrcId == id);
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
            if (_context.TBORCAMENTO == null)
            {
                return Problem("Entity set 'DataContext.Orcamentos'  is null.");
            }
            var orcamentoModel = await _context.TBORCAMENTO.FindAsync(id);
            if (orcamentoModel != null)
            {
                _context.TBORCAMENTO.Remove(orcamentoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrcamentoModelExists(int id)
        {
          return _context.TBORCAMENTO.Any(e => e.OrcId == id);
        }
    }
}
