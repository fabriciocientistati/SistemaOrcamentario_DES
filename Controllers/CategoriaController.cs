using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Helper;
using SistemaOrcamentario.Models;
using SistemaOrcamentario.Services;

namespace SistemaOrcamentario.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly DataContext _context;
        private readonly ISessao _sessao;
        private readonly IService<CategoriaModel> _service;

        public CategoriaController(DataContext context, ISessao sessao, IService<CategoriaModel> service)
        {
            _context = context;
            _sessao = sessao;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.FindAll());
        }

        public IActionResult Details(int? id)
        {
            if (id == null || _context.TBCATEGORIA == null)
            {
                return NotFound();
            }

            var categoria = _context.TBCATEGORIA.FirstOrDefault(x => x.CatId == id);
            var produtos = _context.TBPRODUTO.Where(x => x.CatId == id).ToList();
            var viewModel = new ViewModel { Categoria = categoria, Produtos = produtos};

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaModel categoria)
        {
            if (categoria == null)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                   var usuId = _sessao.ObterIdUsuarioLogado().ToString();

                   if (int.TryParse(usuId, out int parsedUsuId))
                    {
                        categoria.CatIncPor = parsedUsuId;
                        categoria.CatIncEm = DateTime.Now;
                    }

                    await _service.Create(categoria);
                    TempData["MessageSuccess"] = "Categoria cadastrada com sucesso!";

                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                TempData["MessageErro"] = $"Ops, Não foi possível cadastrar a categoria";
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TBCATEGORIA == null)
            {
                return NotFound();
            }

            var categoriaModel = await _context.TBCATEGORIA.FindAsync(id);
            if (categoriaModel == null)
            {
                return NotFound();
            }
            return View(categoriaModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoriaModel categoria)
        {
            if (categoria == null)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var usuIdLogado = _sessao.ObterIdUsuarioLogado().ToString();

                    if (int.TryParse(usuIdLogado, out int parseUsuId))
                    {
                        categoria.CatAltPor = parseUsuId;
                        categoria.CatAltEm = DateTime.Now;
                    }

                    await _service.Update(categoria);

                    TempData["MessageSuccess"] = "Categoria atualizada!";

                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                TempData["MessageErro"] = $"Ops, não foi possível atualizar categoria!";
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

            TempData["MessageSuccess"] = "Categoria excluida com sucesso!";

            return RedirectToAction("Index");
        }
    }
}
