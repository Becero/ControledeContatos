using ControledeContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControledeContatos.Models
{
    public class EmpregoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a descrição da vaga")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Digite o valor a ser oferecido")]
        public float Valor { get; set; }

        [Required(ErrorMessage = "Digite o endereço do local")]
        public string Localizacao { get; set; }     
       

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
