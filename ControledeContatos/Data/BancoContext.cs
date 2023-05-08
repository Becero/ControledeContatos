using ControledeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControledeContatos.Data
{
    public class BancoContext : DbContext //Conexao com banco de dados hederdando o contexto / referencia do Core.
    {
        //Metodo Construtor, segue o nome da classe
        public BancoContext(DbContextOptions <BancoContext> options): base(options) //injetar como parametro de entrada e dentro vai tipar como bancocontext
        { 
        }   

        public DbSet<ContatoModel> Contatos { get; set; }
    }
}
