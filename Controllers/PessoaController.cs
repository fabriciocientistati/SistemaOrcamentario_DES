//using iTextSharp.text.pdf;
//using iTextSharp.text;
using Microsoft.AspNetCore.Mvc;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Models;
using System.Collections.Generic;
using System.Linq;
using SistemaOrcamentario.Filters;
using System;
using Microsoft.EntityFrameworkCore;
using SistemaOrcamentario.Helper;
using SistemaOrcamentario.Services;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace SistemaOrcamentario.Controllers
{
    [PaginaParaUsuarioLogado]
    public class PessoaController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ISessao _sessao;
        private readonly IService<PessoaModel> _service;

        public PessoaController(DataContext dataContext, ISessao sessao, IService<PessoaModel> service)
        {
            _dataContext = dataContext;
            _sessao = sessao;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var pessoas = await _service.FindAll();
            return View(pessoas);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            PessoaModel pessoa = _dataContext.TBPESSOA.FirstOrDefault(x => x.PesId == id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        public IActionResult Details(int? id)
        {
            PessoaModel pessoa = _dataContext.TBPESSOA.FirstOrDefault(x => x.PesId == id);
            List<OrcamentoModel> orcamentos = _dataContext.TBORCAMENTO.Where(x => x.PesId == id).ToList();
            var viewModel = new ViewModel { Pessoa = pessoa, Orcamento = orcamentos };

            return View(viewModel);
        }

        public async Task<IActionResult> ListarOrcamentosPessoaId(int? id)
        {
            List<OrcamentoModel> orcamentos = await _dataContext.TBORCAMENTO.Where(x => x.PesId == id).ToListAsync();
            return PartialView("_PessoaOrcamentosIndex", orcamentos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PessoaModel pessoa)
        {
            if (pessoa == null)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(pessoa.PesCpf) &&
                        _dataContext.TBPESSOA.Any(p => p.PesCpf == pessoa.PesCpf && p.PesId != pessoa.PesId))
                    {
                        TempData["MessageErro"] = "Já existe cliente com esse CPF!";
                        return View(pessoa);
                    }

                    if (!string.IsNullOrEmpty(pessoa.PesCnpj) &&
                        _dataContext.TBPESSOA.Any(p => p.PesCnpj == pessoa.PesCnpj && p.PesId != pessoa.PesId))
                    {
                        TempData["MessageErro"] = "Já existe cliente com esse CNPJ!";
                        return View(pessoa);
                    }

                    var UsuId = _sessao.ObterIdUsuarioLogado().ToString();

                    if (int.TryParse(UsuId, out int parsedUsuId))
                    {
                        pessoa.PesIncPor = parsedUsuId;
                        pessoa.PesIncEm = DateTime.Now;
                    }

                    await _service.Create(pessoa);
                    TempData["MessageSuccess"] = "Cliente cadastrado com sucesso!";

                    return RedirectToAction("Index");
                }
            }

            catch (Exception)
            {
                TempData["MessageErro"] = $"Ops, Não foi possível cadastrar cliente!";
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PessoaModel pessoa)
        {
            try
            {
                if (pessoa == null)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(pessoa.PesCpf) &&
                        _dataContext.TBPESSOA.Any(p => p.PesCpf == pessoa.PesCpf && p.PesId != pessoa.PesId))
                    {
                        TempData["MessageErro"] = "Já existe cliente com esse CPF!";
                        return View(pessoa);
                    }

                    if (!string.IsNullOrEmpty(pessoa.PesCnpj) &&
                        _dataContext.TBPESSOA.Any(p => p.PesCnpj == pessoa.PesCnpj && p.PesId != pessoa.PesId))
                    {
                        TempData["MessageErro"] = "Já existe cliente com esse CNPJ!";
                    }

                    var UsuIdLogado = _sessao.ObterIdUsuarioLogado().ToString();

                    if (int.TryParse(UsuIdLogado, out int parseUsuId))
                    {
                        pessoa.PesAltPor = parseUsuId;
                        pessoa.PesAltEm = DateTime.Now;
                    }

                    await _service.Update(pessoa);
                    TempData["MessageSuccess"] = "Cliente atualizado!";

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                TempData["MessageErro"] = $"Ops, não foi possível atualizar cliente!";
                return RedirectToAction("Edit");
            }

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            await _service.Delete(id);

            TempData["MessageSuccess"] = "Cliente excluido com sucesso!";

            return RedirectToAction("Index");
        }
    }
}
