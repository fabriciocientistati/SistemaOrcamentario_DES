using Microsoft.AspNetCore.Mvc;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Filters;
using SistemaOrcamentario.Helper;
using SistemaOrcamentario.Models;
using System;
using System.Linq;

namespace SistemaOrcamentario.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ISessao _sessao;
        private readonly IEmail _email;
        public LoginController(DataContext dataContext, ISessao sessao, IEmail email)
        {
            _dataContext = dataContext;
            _sessao = sessao;
            _email = email;
        }
        public IActionResult Index()
        {
            //Se usuario estiver logado, redirecione para Index Pessoa

            if(_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Pessoa");

            return View();
        }

        public IActionResult RedefinirSenha() 
        { 
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _dataContext.TBUSUARIO.FirstOrDefault(x => x.UsuLogin.ToUpper() == loginModel.Login.ToUpper());
                    if (usuario != null)
                    {
                        if (loginModel.Login.ToUpper() == usuario.UsuLogin.ToUpper() && loginModel.Senha.GerarHash() == usuario.UsuSenha)
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Pessoa");
                        }
                        TempData["MessageErro"] = "Senha do usuário é invalida, tente novamente.";
                    }
                    TempData["MessageErro"] = "Usuário e/ou senha inválido(a). Por favor. tente novamente.";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MessageErro"] = $"Ops, Não conseguimos realizar o login, tente novamente: detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost] 
        public IActionResult EnviarLinkRedefinirSenha(RedefinirSenhaModel redefinirSenha) 
        { 
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _dataContext.TBUSUARIO.FirstOrDefault(x => x.UsuEmail.ToUpper() == redefinirSenha.Email.ToUpper() && x.UsuLogin.ToUpper() == redefinirSenha.Login.ToUpper());
                
                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua nova senha é: {novaSenha}";

                        bool emailEnviado = _email.Enviar(usuario.UsuEmail, "Sistema de Cadastro - Nova Senha", mensagem);
                       
                        if (emailEnviado)
                        {
                            _dataContext.Update(usuario);
                            _dataContext.SaveChanges();
                            TempData["MessageSuccess"] = $"Enviamos para seu e-mail cadastrado uma nova senha.";
                        }
                        else
                        {
                            TempData["MessageErro"] = "Não conseguimos enviar o e-mail. Por favor, tente novamente.";
                        }

                        return RedirectToAction("Index","Login");
                    }
                    TempData["MessageErro"] = "Não conseguimos redefinir sua senha. Por favor, verifique os dados informados.";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MessageErro"] = $"Ops, Não conseguimos redefinir sua senha, tente novamente: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
