namespace ControledeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; } //Representa o codigo do contato numerado
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }
    }
}
