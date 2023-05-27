using System.ComponentModel.DataAnnotations;

namespace ControledeContatos.Models
{
    public class AlterarSenhaModel
    {
        public int  Id { get; set; }
        [Required(ErrorMessage ="Digite a senha atual do Usuario")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Digite a nova senha do Usuario")]
        public string NovaSenha{ get; set; }

        [Required(ErrorMessage = "Confirme a nova senha  do Usuario")]
        [Compare("NovaSenha", ErrorMessage ="Senha não Confere com a nova senha")]
        public string ConfirmarNovaSenha { get; set; }
    }
}
