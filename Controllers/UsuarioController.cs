using Microsoft.AspNetCore.Mvc;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SistemaOrcamentario.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly DataContext _dataContext;

        public UsuarioController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            IEnumerable<UsuarioModel> usuario = _dataContext.Usuarios;

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

            UsuarioModel usuario = _dataContext.Usuarios.FirstOrDefault(x => x.ID == id);

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

            UsuarioModel usuario = _dataContext.Usuarios.FirstOrDefault(x => x.ID == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }


        [HttpPost]
        public IActionResult Create(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Usuarios.Add(usuario);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Usuarios.Update(usuario);
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
                _dataContext.Usuarios.Remove(usuario);
                _dataContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(usuario);
        }

    }
}
