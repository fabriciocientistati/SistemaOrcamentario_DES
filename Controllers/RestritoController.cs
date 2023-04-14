using Microsoft.AspNetCore.Mvc;
using SistemaOrcamentario.Filters;

namespace SistemaOrcamentario.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
