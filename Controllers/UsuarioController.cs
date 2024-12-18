﻿using Microsoft.AspNetCore.Mvc;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Filters;
using SistemaOrcamentario.Helper;
using SistemaOrcamentario.Models;
using SistemaOrcamentario.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaOrcamentario.Controllers
{
    [PaginaRestritaParaAdmin]
    public class UsuarioController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ISessao _sessao;
        private readonly IService<UsuarioModel> _service;

        public UsuarioController(DataContext dataContext, ISessao sessao, IService<UsuarioModel> service)
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
            if (id == 0)
            {
                return NotFound();
            }

            var usuario = _dataContext.TBUSUARIO.FirstOrDefault(x => x.UsuId == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioModel usuario)
        {
            if (usuario == null)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    if (_dataContext.TBUSUARIO.Any(u => u.UsuLogin == usuario.UsuLogin))
                    {
                        TempData["MessageErro"] = "Já existe usuário com esse login!";
                        return View(usuario);
                    }

                    var usuarioLogado = _sessao.ObterIdUsuarioLogado().ToString();

                    if (int.TryParse(usuarioLogado, out int parseUsuarioLogado))
                    {
                        usuario.UsuIncPor = parseUsuarioLogado;
                        usuario.UsuIncEm = DateTime.Now;
                    }

                    usuario.SetSenhaHas();
                    await _service.Create(usuario);

                    TempData["MessageSuccess"] = "Usuário cadastrado com sucesso!";

                    return RedirectToAction(nameof(Index));
                }
            }

            catch (Exception)
            {
                TempData["MessageErro"] = $"Ops, Não foi possível cadastrar usuário!";
                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Edit(UsuarioModel usuario)
        {
            if (usuario == null)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    if (_dataContext.TBUSUARIO.Any(u => u.UsuLogin == usuario.UsuLogin && u.UsuId == usuario.UsuId))
                    {
                        var usuIdLogado = _sessao.ObterIdUsuarioLogado().ToString();

                        if (int.TryParse(usuIdLogado, out int parseUsuId))
                        {
                            usuario.UsuAltPor = parseUsuId;
                            usuario.UsuAltEm = DateTime.Now;
                        }

                        await _service.Update(usuario);
                        TempData["MessageSuccess"] = "Usuário atualizado!";

                        return RedirectToAction("Index");
                    }
                    TempData["MessageErro"] = "Já existe usuário com esse Login!";
                    return RedirectToAction("Edit");
                }
            }
            catch (Exception)
            {
                TempData["MessageErro"] = "Ops, não foi possível atualizar usuário(a)!";
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

            TempData["MessageSuccess"] = "Usuário excluido com sucesso!";

            return RedirectToAction("Index");
        }
    }
}
