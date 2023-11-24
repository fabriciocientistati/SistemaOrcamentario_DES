using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceStack;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Filters;
using SistemaOrcamentario.Helper;
using SistemaOrcamentario.Models;

namespace SistemaOrcamentario.Controllers
{
    [PaginaParaUsuarioLogado]
    public class OrcamentoController : Controller
    {
        private readonly DataContext _context;
        private readonly ISessao _sessao;

        public OrcamentoController(DataContext context, ISessao sessao)
        {
            _context = context;
            _sessao = sessao;

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

        public IActionResult Create(int? id)
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
            if (model == null)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var usuId = _sessao.ObterIdUsuarioLogado().ToString();

                    if (int.TryParse(usuId, out int parseUsuId))
                    {
                        model.Orcamento.OrcIncPor = parseUsuId;
                        model.Orcamento.OrcIncEm = DateTime.Now;
                    }

                    _context.TBORCAMENTO.Add(model.Orcamento);
                    await _context.SaveChangesAsync();

                    TempData["MessageSuccess"] = "Orçamento criado com sucesso!";

                    return RedirectToAction("Index", "Pessoa");
                }
            }
            catch (Exception)
            {
                TempData["MessageErro"] = $"Ops, Não foi possível criar orçamento!";
            }

            ViewBag.PesId = new SelectList(_context.TBPESSOA, "PesId", "PesNome", model.Orcamento.PesId);
            return View(model);
        }


        public async Task<IActionResult> Edit(int id1, int id2)
        {
            if (id1 == 0 && id2 == 0)
            {
                return NotFound();
            }

            var orcamento = await _context.TBORCAMENTO.FindAsync(id1);
            var pessoa = await _context.TBORCAMENTO.FindAsync(id2);

            if (orcamento == null && pessoa == null)
            {
                return NotFound();
            }

            ViewData["PesId"] = new SelectList(_context.TBPESSOA, "PesId", "PesNome", id2);
            return View(orcamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ViewPessoaOrcamento model)
        {
            if (model == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.TBORCAMENTO.Update(model.Orcamento);
                    await _context.SaveChangesAsync();

                    TempData["MessageSuccess"] = "Orçamento atualizado com sucesso!";

                    return RedirectToAction("Index", "Pessoa");
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!OrcamentoModelExists(model.Orcamento.OrcId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        TempData["MessageErro"] = $"Ops, Não foi possível atualizar orçamento!";
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PesId"] = new SelectList(_context.TBPESSOA, "PesId", "PesNome", model.Orcamento.PesId);
            return View(model);
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
