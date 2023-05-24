using ControledeContatos.Models;

namespace ControledeContatos.Repositorio { 

    public interface IUsuarioRepositorio
    {
        //metodos contrato repositorio
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel BuscarPorEmailELogin(string email, string login);
        UsuarioModel ListarPorId(int id); //carrega os valores na pagina editar
        List<UsuarioModel> BuscarTodos(); //lista os contatos na home
        UsuarioModel Adicionar(UsuarioModel usuario); //salva os contatos no BD
        UsuarioModel Atualizar(UsuarioModel usuario); //serve para pagina de editar
        bool Apagar(int id);
    }
}
