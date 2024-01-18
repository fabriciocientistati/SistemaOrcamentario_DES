using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        public ProdutoController(DataContext context, IWebHostEnvironment sitema, IService<ProdutoModel> service,
            ISessao sessao)
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
        public async Task<IActionResult> Create(ProdutoModel produtoModel, IFormFile arquivo)
        {
            if (produtoModel == null && arquivo == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(produtoModel.ProNome) &&
                    _context.TBPRODUTO.Any(p => p.ProNome == produtoModel.ProNome))
                {
                    TempData["MessageErro"] = "Já existe produto com esse nome.";
                    return View(produtoModel);
                }
                
                if (arquivo != null)
                {
                    var caminhoImagem = Path.Combine(_caminhoServidor, "images");
                    var novoNomeImagem = Guid.NewGuid().ToString() + "_" + arquivo.FileName;
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
                }

                var usuId = _sessao.ObterIdUsuarioLogado().ToString();

                if (int.TryParse(usuId, out int parseUsuId))
                {
                    produtoModel.ProIncPor = parseUsuId;
                    produtoModel.ProIncEm = DateTime.Now;
                }

                await _service.Create(produtoModel);
                TempData["MessageSuccess"] = "Produto cadastrado com sucesso!";

                return RedirectToAction("Index");
            }

            ViewData["CatId"] = new SelectList(_context.TBCATEGORIA, "CatId", "CatNome", produtoModel.CatId);
            return View(produtoModel);
        }

        public async Task<IActionResult> Edit(int proId, int catId)
        {
            if (proId == 0 && catId == 0)
            {
                return NotFound();
            }

            var produto = await _context.TBPRODUTO.FirstOrDefaultAsync(x => x.ProId == proId);
            var categoria = await _context.TBCATEGORIA.FirstOrDefaultAsync(x => x.CatId == catId);
            var viewProduto = new ViewProduto { Produtos = produto };

            if (produto == null || categoria == null)
            {
                return NotFound();
            }


            ViewData["CatId"] = new SelectList(_context.TBCATEGORIA, "CatId", "CatNome", catId);
            // ViewBag.CatId = new SelectList(_context.TBPRODUTO, "CatId", "CatNome");
            return View(viewProduto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ViewProduto model, IFormFile arquivo)
        {
            if (model == null && arquivo == null)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(model.Produtos.ProNome) &&
                        _context.TBPRODUTO.Any(p => p.ProNome == model.Produtos.ProNome && p.ProId != model.Produtos.ProId))
                    {
                        TempData["MessageErro"] = "Já existe produto com esse nome. ";
                        return View(model);
                    }
                        
                    if (arquivo != null)
                    {
                        var extensoesPermitidas = new[] { "image/jpg", "image/jpeg", "image/png" };

                        if (!extensoesPermitidas.Contains(arquivo.ContentType))
                        {
                            TempData["MessageErro"] = "É permitido apenas imagens.";
                            return View(model);
                        }
                    
                        var caminhoImagem = Path.Combine(_caminhoServidor, "images");
                        var novoNomeImagem = Guid.NewGuid().ToString() + "_" + arquivo.FileName;
                        var caminhoCompleto = Path.Combine(caminhoImagem, novoNomeImagem);


                        if (System.IO.File.Exists(novoNomeImagem))
                        {
                            TempData["MessageErro"] = $"Ops, uma imagem com o mesmo nome já existe!";
                            return RedirectToAction("Edit", "Produto");
                        }

                        using (var stream = System.IO.File.Create(caminhoCompleto))
                        {
                            await arquivo.CopyToAsync(stream);
                        }

                        if (!Directory.Exists(caminhoImagem))
                        {
                            Directory.CreateDirectory(caminhoImagem);
                        }

                        model.Produtos.ProImagemUrl = novoNomeImagem;                        
                    }

                    var usuId = _sessao.ObterIdUsuarioLogado().ToString();

                    if (int.TryParse(usuId, out int parseUsuId))
                    {
                        model.Produtos.ProAltPor = parseUsuId;
                        model.Produtos.ProAltEm = DateTime.Now;
                    }

                    await _service.Update(model.Produtos);

                    TempData["MessageSuccess"] = "Produto atualizado com sucesso!";

                    return RedirectToAction("Index", "Produto");
                }
            }
            catch (Exception)
            {
                TempData["MessageErro"] = $"Ops, não foi possível atualizar produto!";
                return View(model);
            }

            ViewData["CatId"] = new SelectList(_context.TBCATEGORIA, "CatId", "CatNome", model.Produtos.CatId);
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0 || _context.TBPRODUTO == null)
            {
                return NotFound();
            }

            await _service.Delete(id);

            TempData["MessageSuccess"] = "Produto excluido com sucesso!";

            return RedirectToAction("Index");
        }
    }
}