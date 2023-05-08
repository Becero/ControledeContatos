using ControledeContatos.Models;

namespace ControledeContatos.Repositorio { 

    public interface IContatoRepositorio
    {
        //metodos contrato repositorio
        ContatoModel ListarPorId(int id); //carrega os valores na pagina editar

        List<ContatoModel> BuscarTodos(int id); //lista os contatos na home

        ContatoModel Adicionar(ContatoModel contato); //salva os contatos no BD

        ContatoModel Atualizar(ContatoModel contato); //serve para pagina de editar

        bool Apagar(int id);
    }
}
