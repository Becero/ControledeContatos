using ControledeContatos.Data;
using ControledeContatos.Models;

namespace ControledeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _context;
       
        public ContatoRepositorio(BancoContext bancoContext)
        {
           this._context = bancoContext;
        }

        //teste
        public ContatoModel ListarPorId(int id)
        {
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return _context.Contatos.FirstOrDefault(x => x.Id == id); //lista o contato correspondente a esse if
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        public List<ContatoModel> BuscarTodos()
        {
           return _context.Contatos.ToList();
        }
       
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();

            return contato;
            // gravar no banco de dados
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);
            
            if(contatoDB == null) throw new Exception("Houve um erro na atualização do contato!");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _context.Contatos.Update(contatoDB);
            _context.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);

            if(contatoDB == null) throw new Exception("Houve um erro na deleção do contato!");

            _context.Contatos.Remove(contatoDB);
            _context.SaveChanges();

            return true;
        }
        
    }
}
