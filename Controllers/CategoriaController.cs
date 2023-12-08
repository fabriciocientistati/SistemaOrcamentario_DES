using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public CategoriaController(DataContext context, Sessao sessao, IService<CategoriaModel> service)
        {
            _context = context;
            _sessao = sessao;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
              return View(await _context.TBCATEGORIA.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TBCATEGORIA == null)
            {
                return NotFound();
            }

            var categoriaModel = await _context.TBCATEGORIA
                .FirstOrDefaultAsync(m => m.CatId == id);
            if (categoriaModel == null)
            {
                return NotFound();
            }

            return View(categoriaModel);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CatId,CatNome,CatIncPor,CatIncEm,CatAltPor,CatAltEm")] CategoriaModel categoriaModel)
        {
            if (id != categoriaModel.CatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaModelExists(categoriaModel.CatId))
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
            return View(categoriaModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TBCATEGORIA == null)
            {
                return NotFound();
            }

            var categoriaModel = await _context.TBCATEGORIA
                .FirstOrDefaultAsync(m => m.CatId == id);
            if (categoriaModel == null)
            {
                return NotFound();
            }

            return View(categoriaModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TBCATEGORIA == null)
            {
                return Problem("Entity set 'DataContext.TBCATEGORIA'  is null.");
            }
            var categoriaModel = await _context.TBCATEGORIA.FindAsync(id);
            if (categoriaModel != null)
            {
                _context.TBCATEGORIA.Remove(categoriaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaModelExists(int id)
        {
          return _context.TBCATEGORIA.Any(e => e.CatId == id);
        }
    }
}
