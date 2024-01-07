using Microsoft.AspNetCore.Mvc;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Helper;
using SistemaOrcamentario.Models;
using System;
using System.Linq;

namespace SistemaOrcamentario.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ISessao _sessao;
        public AlterarSenhaController(DataContext dataContext, ISessao sessao)
        {
            _dataContext = dataContext;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenha)
        {
            try
            {
                UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                alterarSenha.Id = usuarioLogado.UsuId;

                UsuarioModel usuarioDB = _dataContext.TBUSUARIO.FirstOrDefault(x => x.UsuId == alterarSenha.Id);

                if (usuarioDB == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado!");

                if (!usuarioDB.SenhaValida(alterarSenha.senhaAtual)) throw new Exception("Senha atual não confere!");

                if (usuarioDB.SenhaValida(alterarSenha.novaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual!");

                if (ModelState.IsValid)
                {
                    usuarioDB.SetNovaSenha(alterarSenha.novaSenha);
                    usuarioDB.UsuIncEm = DateTime.Now;

                    _dataContext.TBUSUARIO.Update(usuarioDB);
                    _dataContext.SaveChanges();

                    TempData["MessageSuccess"] = "Senha alterada com sucesso!";
                    return View("Index", alterarSenha);
                }

                return View("Index", alterarSenha);
            }
            catch (Exception erro)
            {
                TempData["MessageErro"] = $"Ops, não conseguimos alterar sua senha, tente novamente, detalhe do erro: {erro.Message}";
                return View("Index", alterarSenha);
            }
        }
    }
}
