using ControledeContatos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControledeContatos.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar (LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos realizar seu logins,tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
