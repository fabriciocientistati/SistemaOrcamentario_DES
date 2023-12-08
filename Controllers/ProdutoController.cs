using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Models;

namespace SistemaOrcamentario.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly DataContext _context;
        private readonly string _caminhoServidor;

        public ProdutoController(DataContext context, IWebHostEnvironment sitema)
        {
            _context = context;
            _caminhoServidor = sitema.WebRootPath;
        }

        // GET: Produto
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.TBPRODUTO.Include(p => p.Categoria);
            return View(await dataContext.ToListAsync());
        }

        // GET: Produto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TBPRODUTO == null)
            {
                return NotFound();
            }

            var produtoModel = await _context.TBPRODUTO
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.ProId == id);
            if (produtoModel == null)
            {
                return NotFound();
            }

            return View(produtoModel);
        }

        // GET: Produto/Create
        public IActionResult Create()
        {
            ViewData["CatId"] = new SelectList(_context.TBCATEGORIA, "CatId", "CatNome");
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProId,ProNome,ProDesc,ProPreco,ProQuantidadeEmEstoque,ProImagemUrl,CatId,ProIncPor,ProIncEm,ProAltPor,ProAltEm")] ProdutoModel produtoModel, IFormFile arquivo)
        {
            if (arquivo != null)
            {
                var caminhoImagem = _caminhoServidor + "\\images\\";
                var novoNomeImagem = Guid.NewGuid().ToString() + "_" + arquivo.FileName;

                using (var stream = System.IO.File.Create(caminhoImagem + novoNomeImagem))
                {
                    await arquivo.CopyToAsync(stream);
                }

                if (!Directory.Exists(caminhoImagem))
                {
                    Directory.CreateDirectory(caminhoImagem);
                }

                produtoModel.ProImagemUrl = null;
                _context.Add(produtoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatId"] = new SelectList(_context.TBCATEGORIA, "CatId", "CatNome", produtoModel.CatId);
            return View(produtoModel);
        }


        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TBPRODUTO == null)
            {
                return NotFound();
            }

            var produtoModel = await _context.TBPRODUTO.FindAsync(id);
            if (produtoModel == null)
            {
                return NotFound();
            }
            ViewData["CatId"] = new SelectList(_context.TBCATEGORIA, "CatId", "CatNome", produtoModel.CatId);
            return View(produtoModel);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProId,ProNome,ProDesc,ProPreco,ProQuantidadeEmEstoque,ProImagemUrl,CatId,ProIncPor,ProIncEm,ProAltPor,ProAltEm")] ProdutoModel produtoModel)
        {
            if (id != produtoModel.ProId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoModelExists(produtoModel.ProId))
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
            ViewData["CatId"] = new SelectList(_context.TBCATEGORIA, "CatId", "CatNome", produtoModel.CatId);
            return View(produtoModel);
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TBPRODUTO == null)
            {
                return NotFound();
            }

            var produtoModel = await _context.TBPRODUTO
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.ProId == id);
            if (produtoModel == null)
            {
                return NotFound();
            }

            return View(produtoModel);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TBPRODUTO == null)
            {
                return Problem("Entity set 'DataContext.TBPRODUTO'  is null.");
            }
            var produtoModel = await _context.TBPRODUTO.FindAsync(id);
            if (produtoModel != null)
            {
                _context.TBPRODUTO.Remove(produtoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoModelExists(int id)
        {
            return _context.TBPRODUTO.Any(e => e.ProId == id);
        }
    }
}
