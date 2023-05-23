using ControledeContatos.Helper;
using ControledeContatos.Models;
using ControledeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControledeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepositorio usuarioRepositorio,
                                ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            //Se o Usuario estiver logado, redirecionar para a home

            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }
        [HttpGet]
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index", "Login");
        }

        public IActionResult Entrar (LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        //responsabilidade de verificar se a senha é valida
                        if(usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha invalida.";
                    }

                    TempData["MensagemErro"] = $"Usuario e/ou senha Invalidos(s).Por favor, tente novamente.";                    
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
