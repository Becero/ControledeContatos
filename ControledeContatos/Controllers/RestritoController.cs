using ControledeContatos.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ControledeContatos.Controllers
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
