using ControledeContatos.Models;

namespace ControledeContatos.Repositorio { 

    public interface IUsuarioRepositorio
    {
        //metodos contrato repositorio
       UsuarioModel ListarPorId(int id); //carrega os valores na pagina editar

        List<UsuarioModel> BuscarTodos(); //lista os contatos na home

       UsuarioModel Adicionar(UsuarioModel usuario); //salva os contatos no BD

        UsuarioModel Atualizar(UsuarioModel usuario); //serve para pagina de editar

        bool Apagar(int id);
    }
}
