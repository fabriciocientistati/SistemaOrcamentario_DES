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

        public async Task<IActionResult> Index()
        {
            var dataContext = _context.TBORCAMENTO.Include(o => o.OrcamentoPessoa);
            return View(await dataContext.ToListAsync());
        }

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

        public IActionResult Create(int? id) //Carrega o ID que vem por parametro
        {
            var PesOrcamento = new ViewPessoaOrcamento();

            if (id == null || id == 0)
            {
                ViewData["PesId"] = new SelectList(_context.TBPESSOA, "PesId", "PesNome"); //Lista nomes no select aleatório

                return View();
            }
            ViewBag.PesId = new SelectList(_context.TBPESSOA, "PesId", "PesNome", id); //Lista nome no select por parametro
            return View(PesOrcamento);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ViewPessoaOrcamento model)
        {
            if (ModelState.IsValid)
            {
                _context.TBORCAMENTO.Add(model.Orcamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PesId"] = new SelectList(_context.TBPESSOA, "PesId", "PesNome", model.Orcamento.PesId);
            return View(model);
        }

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
