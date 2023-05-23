using ControledeContatos.Data;
using ControledeContatos.Models;

namespace ControledeContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _context;
       
        public UsuarioRepositorio(BancoContext bancoContext)
        {
           this._context = bancoContext;
        }
        public UsuarioModel BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        //teste
        public UsuarioModel ListarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id); //lista o contato correspondente a esse if
        }

        public List<UsuarioModel> BuscarTodos()
        {
           return _context.Usuarios.ToList();
        }
       
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
                usuario.DataCadastro = DateTime.Now;
                usuario.SetSenhaHash();
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

            return usuario;

            // gravar no banco de dados
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);
            
            if(usuarioDB == null) throw new Exception("Houve um erro na atualização do usuario!");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;



            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);

            if(usuarioDB == null) throw new Exception("Houve um erro na deleção do contato!");

            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges();

            return true;
        }

       
    }
}
