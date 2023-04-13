using Microsoft.AspNetCore.Mvc;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Helper;
using SistemaOrcamentario.Models;
using System.Linq;

namespace SistemaOrcamentario.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ISessao _sessao;
        public LoginController(DataContext dataContext, ISessao sessao)
        {
            _dataContext = dataContext;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            //Se usuario estiver logado, redirecione para Index Pessoa

            if(_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Pessoa");

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
            if (ModelState.IsValid)
            {
                UsuarioModel usuario = _dataContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == loginModel.Login.ToUpper());

                if (loginModel.Login == usuario.Login && loginModel.Senha == usuario.Senha)
                {
                    _sessao.CriarSessaoDoUsuario(usuario);
                    return RedirectToAction("Index","Pessoa");
                }
            }
            TempData["ErrorMessage"] = "Usuário não encontrado";
            return RedirectToAction("Index");
        }
    }
}
