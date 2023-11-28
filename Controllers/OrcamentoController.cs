using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Filters;
using SistemaOrcamentario.Helper;
using SistemaOrcamentario.Models;
using SistemaOrcamentario.Services;

namespace SistemaOrcamentario.Controllers
{
    [PaginaParaUsuarioLogado]
    public class OrcamentoController : Controller
    {
        private readonly DataContext _context;
        private readonly ISessao _sessao;
        private readonly IService<OrcamentoModel> _service;

        public OrcamentoController(DataContext context, ISessao sessao, IService<OrcamentoModel> service)
        {
            _context = context;
            _sessao = sessao;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var dataContext = _context.TBORCAMENTO.Include(o => o.OrcamentoPessoa);
            return View(await dataContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == 0 || _context.TBORCAMENTO == null)
            {
                return NotFound();
            }

            var orcamento = await _context.TBORCAMENTO
                .Include(o => o.OrcamentoPessoa)
                .FirstOrDefaultAsync(m => m.PesId == id);
            if (orcamento == null)
            {
                return NotFound();
            }

            return View(orcamento);
        }

        public IActionResult Create(int? id)
        {
            var pesOrcamento = new ViewPessoaOrcamento();

            if (id == 0)
            {
                ViewData["PesId"] = new SelectList(_context.TBPESSOA, "PesId", "PesNome");

                return View();
            }

            ViewBag.PesId = new SelectList(_context.TBPESSOA, "PesId", "PesNome", id);
            return View(pesOrcamento);
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
                return RedirectToAction("Edit");
            }

            ViewBag.PesId = new SelectList(_context.TBPESSOA, "PesId", "PesNome", model.Orcamento.PesId);
            return View(model);
        }

        public async Task<IActionResult> Edit(int orcId, int pesId)
        {
            if (orcId == 0 || pesId == 0)
            {
                return NotFound();
            }
            
            var orcamento = await _context.TBORCAMENTO.FirstOrDefaultAsync(o => o.OrcId == orcId);
            var pessoa = await _context.TBORCAMENTO.FirstOrDefaultAsync(o => o.PesId == pesId);
            var viewModel = new ViewPessoaOrcamento { Orcamento = orcamento };

            if (orcamento == null && pessoa == null)
            {
                return NotFound();
            }

            ViewData["PesId"] = new SelectList(_context.TBPESSOA, "PesId", "PesNome", pesId);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ViewPessoaOrcamento model)
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
                        model.Orcamento.OrcAltPor = parseUsuId;
                        model.Orcamento.OrcAltEm = DateTime.Now;
                    }

                    await _service.Update(model.Orcamento);

                    TempData["MessageSuccess"] = "Orçamento atualizado com sucesso!";

                    return RedirectToAction("Index", "Pessoa");
                }
            }
            catch (Exception)
            {
                TempData["MessageErro"] = $"Ops, não foi possível atualizar orçamento!";
                    return RedirectToAction("Details", "Pessoa");
            }

            ViewData["PesId"] = new SelectList(_context.TBPESSOA, "PesId", "PesNome", model.Orcamento.PesId);
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            
            try
            {
                await _service.Delete(id);
                TempData["MessageSuccess"] = "Orçamento excluído com sucesso!";
                
                return RedirectToAction("Index", "Pessoa");
            }
            catch (Exception)
            {
                TempData["MessageErro"] = "Ops, não foi possível excluir o orçamento!";

                return RedirectToAction("Index", "Pessoa");
            }
        }

        private bool OrcamentoModelExists(int id)
        {
            return _context.TBORCAMENTO.Any(e => e.OrcId == id);
        }
    }
}