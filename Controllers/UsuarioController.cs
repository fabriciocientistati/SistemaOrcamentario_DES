using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Enums;
using SistemaOrcamentario.Filters;
using SistemaOrcamentario.Helper;
using SistemaOrcamentario.Models;
using SistemaOrcamentario.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaOrcamentario.Controllers
{
    [PaginaRestritaParaAdmin]
    public class UsuarioController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ISessao _sessao;
        private readonly IService _service;

        public UsuarioController(DataContext dataContext, ISessao sessao, IService service)
        {
            _dataContext = dataContext;
            _sessao = sessao;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _service.FindAll();
            return View(usuarios);
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

        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    UsuarioModel usuario = _dataContext.TBUSUARIO.FirstOrDefault(x => x.UsuId == id);

        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(usuario);
        //}


        [HttpPost]
        public async Task<IActionResult> Create(UsuarioModel usuario)
        {
            try
            {
                if (_dataContext.TBUSUARIO.Any(u => u.UsuLogin == usuario.UsuLogin))
                {
                    TempData["MessageErro"] = "Já existe um usuário com este login!";
                    return RedirectToAction("Create");
                }

                if (ModelState.IsValid)
                {
                    var UsuarioLogado = _sessao.ObterIdUsuarioLogado().ToString();

                    if (int.TryParse(UsuarioLogado, out int parseUsuarioLogado))
                    {
                        usuario.UsuIncPor = parseUsuarioLogado;
                        usuario.UsuIncEm = DateTime.Now;
                    }

                    usuario.SetSenhaHas();
                    await _service.Create(usuario);
                    TempData["MessageSuccess"] = "Usuário cadastrado com sucesso.";

                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                TempData["MessageErro"] = $"Ops, Não foi possível cadastrar o usuário!";
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UsuarioModel usuario)
        {
            try
            {
                if (_dataContext.TBUSUARIO.Any(u => u.UsuLogin == usuario.UsuLogin && u.UsuId != usuario.UsuId))
                {
                    TempData["MessageErro"] = "Já existe um usuário com este login!";
                    return RedirectToAction("Edit");
                }

                if (ModelState.IsValid)
                {
                    var UsuIdLogado = _sessao.ObterIdUsuarioLogado().ToString();

                    if (int.TryParse(UsuIdLogado, out int parseUsuId))
                    {
                        usuario.UsuAltPor = parseUsuId;
                        usuario.UsuAltEm = DateTime.Now;
                    }

                    await _service.Update(usuario);
                    TempData["MessageSuccess"] = "Usuário alterado com sucesso!";

                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                TempData["MessageErro"] = "Ops, não foi possível alterar o usuário!";
                return RedirectToAction("Edit");
            }

            return View(usuario);
        }


        public async Task<IActionResult> Delete(int id)
        {


            if (id == 0)
            {
                return NotFound();
            }

            await _service.Delete(id);

            TempData["MessageSuccess"] = "Usuário apagado com sucesso!";

           return  RedirectToAction("Index");
        }
    }
}
