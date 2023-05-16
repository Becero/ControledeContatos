using System.ComponentModel.DataAnnotations;

namespace ControledeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; } //Representa o codigo do contato numerado

        [Required(ErrorMessage ="Digite o nome do contato")]
        public string Nome { get; set; }

       
        [Required(ErrorMessage = "Digite o email do contato")]
        [EmailAddress(ErrorMessage = "O email informado nao e validoo")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o celular do contato")]
        [Phone (ErrorMessage = "O celular informado nao e validoo")]
        public string Celular { get; set; }

    }
}
