using Microsoft.AspNetCore.Mvc;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Filters;
using SistemaOrcamentario.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SistemaOrcamentario.Controllers
{
    [PaginaRestritaParaAdmin]
    public class UsuarioController : Controller
    {
        private readonly DataContext _dataContext;

        public UsuarioController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            IEnumerable<UsuarioModel> usuario = _dataContext.TBUSUARIO;

            return View(usuario);
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

            UsuarioModel usuario = _dataContext.TBUSUARIO.FirstOrDefault(x => x.UsuId == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            UsuarioModel usuario = _dataContext.TBUSUARIO.FirstOrDefault(x => x.UsuId == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }


        [HttpPost]
        public IActionResult Create(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario.UsuIncEm = DateTime.Now;
                    usuario.SetSenhaHas();
                    _dataContext.TBUSUARIO.Add(usuario);
                    _dataContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                TempData["MessageErro"] = $"Ops, Login de usuário já existente.";
                return RedirectToAction("Create");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                _dataContext.TBUSUARIO.Update(usuario);
                _dataContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Delete(UsuarioModel usuario) 
        {
            if (ModelState.IsValid)
            {
                _dataContext.TBUSUARIO.Remove(usuario);
                _dataContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(usuario);
        }

    }
}
