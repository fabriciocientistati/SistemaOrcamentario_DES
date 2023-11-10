using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Data;
using SistemaOrcamentario.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SistemaOrcamentario.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly DataContext _dataContext;

        public ProdutoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var produtos = _dataContext.Produtos;
            return View(produtos);
        }

        public IActionResult Create()
        {
            var produtoData = new ProdutoModel();
            return View(produtoData);
        }

        [HttpPost]
        public IActionResult Create(ProdutoModel model)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Add(model);
                _dataContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
