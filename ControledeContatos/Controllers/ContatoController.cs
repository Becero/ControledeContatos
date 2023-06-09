﻿using ControledeContatos.Filters;
using ControledeContatos.Helper;
using ControledeContatos.Models;
using ControledeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControledeContatos.Controllers
{
    [PaginaParaUsuarioLogado] //Adiciona o Filtro 
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly ISessao _sessao;

        public ContatoController(IContatoRepositorio contatoRepositorio,
                                 ISessao sessao)
        {
            _contatoRepositorio = contatoRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            UsuarioModel usuarioLogado =  _sessao.BuscarSessaoDoUsuario();
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos(usuarioLogado.Id);

            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato); //manda pra view o contato que ele mapeou
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        [HttpGet]
        public IActionResult Apagar(int id)
        {
            try
            {
                if (_contatoRepositorio.Apagar(id))
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = $"Ops, algo deu errado, tente novamente";
                }
                return RedirectToAction("Index");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, algo deu errado, tente novamente, detalhos do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastro com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos cadastrar seu contato,tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
           try
           {
             if (ModelState.IsValid)
             {
               _contatoRepositorio.Atualizar(contato);
               TempData["MensagemSucesso"] = "Contato alterado com sucesso";
               return RedirectToAction("Index");
             }
             return View("Editar", contato);
           }
           catch (Exception erro)
           {
             TempData["MensagemErro"] = $"Não conseguimos atualizar seu contato,tente novamente, detalhe do erro:{erro.Message}";
             return RedirectToAction("Index");
           }

        }   
    }
}

