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

namespace SistemaOrcamentario.Controllers
{
    [PaginaParaUsuarioLogado]
    public class PessoaController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ISessao _sessao;

        public PessoaController(DataContext dataContext, ISessao sessao)
        {
            _dataContext = dataContext;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            List<PessoaModel> pessoa = _dataContext.TBPESSOA.Include(x => x.Orcamentos).ToList();
            return View(pessoa);
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

        public IActionResult Delete(int? id)
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

        public IActionResult listarOrcamentosPessoaId(int? id)
        {
            List<OrcamentoModel> orcamentos = _dataContext.TBORCAMENTO.Where(x => x.PesId == id).ToList();
            return PartialView("_PessoaOrcamentosIndex", orcamentos);
        }

        [HttpPost]
        public IActionResult Create(PessoaModel pessoa)
        {
            try
            {
                if (_dataContext.TBPESSOA.Any(p => p.PesCpf == pessoa.PesCpf))
                {
                    TempData["MessageErro"] = "Já existe um cliente com este CPF!";
                    return RedirectToAction("Create");
                }

                if (ModelState.IsValid)
                {
                    var UsuId = _sessao.ObterIdUsuarioLogado().ToString();

                    if (int.TryParse(UsuId, out int parsedUsuId))
                    {
                        pessoa.PesIncPor = parsedUsuId;
                    }

                    pessoa.PesIncEm = DateTime.Now;
                    _dataContext.TBPESSOA.Add(pessoa);
                    _dataContext.SaveChanges();
                    TempData["MessageSuccess"] = "Cliente cadastrado com sucesso.";

                    return RedirectToAction("Index");
                }
            }
            catch (Exception erro)
            {
                ViewData["MessageErro"] = $"Ops, não foi possível efetuar o cadastro.{erro.Message}";
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        [HttpPost]
        public IActionResult Edit(PessoaModel pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dataContext.TBPESSOA.Update(pessoa);
                    _dataContext.SaveChanges();
                    TempData["MessageSuccess"] = "Cadastro atualização.";

                    return RedirectToAction("Index");
                }

                TempData["MessageErro"] = "Não foi possível atualizar o cadastro.";
                return View();
            }
            catch (Exception erro)
            {
                TempData["MessageErro"] = $"Ops, não foi possível atualizar o cadastro: detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete(PessoaModel pessoa)
        {
            if (pessoa == null)
            {
                return NotFound();
            }

            _dataContext.TBPESSOA.Remove(pessoa);
            _dataContext.SaveChanges();
            TempData["MessageSuccess"] = "Sucesso: Deletado com sucesso!";

            return RedirectToAction("Index");
        }
    }
}
