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
using SistemaOrcamentario.Helper;
using SistemaOrcamentario.Models;
using SistemaOrcamentario.Services;

namespace SistemaOrcamentario.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly DataContext _context;
        private readonly string _caminhoServidor;
        private readonly IService<ProdutoModel> _service;
        private readonly ISessao _sessao;

        public ProdutoController(DataContext context, IWebHostEnvironment sitema, IService<ProdutoModel> service, ISessao sessao)
        {
            _context = context;
            _caminhoServidor = sitema.WebRootPath;
            _service = service;
            _sessao = sessao;
        }
        
        public async Task<IActionResult> Index()
        {
            var produtos = await _service.FindAll();

            return View(produtos);
        }
        
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
        
        public IActionResult Create()
        {
            ViewData["CatId"] = new SelectList(_context.TBCATEGORIA, "CatId", "CatNome");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProId,ProNome,ProDesc,ProPreco,ProQuantidadeEmEstoque,ProImagemUrl,CatId,ProIncPor,ProIncEm,ProAltPor,ProAltEm")] ProdutoModel produtoModel, IFormFile arquivo)
        {
            if (produtoModel == null || arquivo == null)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                var caminhoImagem = Path.Combine(_caminhoServidor, "images");
                var novoNomeImagem = Guid.NewGuid().ToString()+ "_" + arquivo.FileName;
                var caminhoCompleto = Path.Combine(caminhoImagem, novoNomeImagem);
                
                using (var stream = System.IO.File.Create(caminhoCompleto))
                {
                    await arquivo.CopyToAsync(stream);
                }

                if (!Directory.Exists(caminhoImagem))
                {
                    Directory.CreateDirectory(caminhoImagem);
                }

                produtoModel.ProImagemUrl = novoNomeImagem;

                var usuId = _sessao.ObterIdUsuarioLogado().ToString();

                if (int.TryParse(usuId, out int parseUsuId))
                {
                    produtoModel.ProIncPor = parseUsuId;
                    produtoModel.ProIncEm = DateTime.Now;
                }    
                    
                _context.Add(produtoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatId"] = new SelectList(_context.TBCATEGORIA, "CatId", "CatNome", produtoModel.CatId);
            return View(produtoModel);
        }
        
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
