using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SistemaOrcamentario.Controllers
{
    public class PessoaController : Controller
    {
        private readonly DataContext _dataContext;

        public PessoaController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            IEnumerable<PessoaModel> pessoa = _dataContext.Pessoas;
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

            PessoaModel pessoa = _dataContext.Pessoas.FirstOrDefault(x => x.ID == id);

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

            PessoaModel pessoa = _dataContext.Pessoas.FirstOrDefault(x => x.ID == id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        public IActionResult Details(int? id)
        {
            PessoaModel pessoa = _dataContext.Pessoas.FirstOrDefault(x => x.ID == id);

            return View(pessoa);
        }

        [HttpPost]
        public IActionResult Create(PessoaModel pessoa)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Pessoas.Add(pessoa);
                _dataContext.SaveChanges();
                TempData["MessageSuccess"] = "Sucesso: Cadastro realizado!";

                return RedirectToAction("Index");
            }
            TempData["MessageError"] = "Erro: Cadastro não realizado!";
                return View();
        }

        [HttpPost]
        public IActionResult Edit(PessoaModel pessoa)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Pessoas.Update(pessoa);
                _dataContext.SaveChanges();
                TempData["MessageSuccess"] = "Sucesso: Atualização realizada!";

                return RedirectToAction("Index");
            }

            TempData["MessageError"] = "Erro: Atualização não realizada!";
                return View();
        }

        [HttpPost]
        public IActionResult Delete(PessoaModel pessoa)
        {
            if (pessoa == null)
            {
                return NotFound();
            }

            _dataContext.Pessoas.Remove(pessoa);
            _dataContext.SaveChanges();
            TempData["MessageSuccess"] = "Sucesso: Deletado com sucesso!";

            return RedirectToAction("Index");
        }
    }
}
