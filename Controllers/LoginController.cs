using Microsoft.AspNetCore.Mvc;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Models;
using System.Linq;

namespace SistemaOrcamentario.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _dataContext;

        public LoginController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                UsuarioModel usuario = _dataContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == loginModel.Login.ToUpper());

                if (loginModel.Login == usuario.Login && loginModel.Senha == usuario.Senha)
                {
                    return RedirectToAction("Index","Pessoa");
                }
            }
            return View();
        }
    }
}
