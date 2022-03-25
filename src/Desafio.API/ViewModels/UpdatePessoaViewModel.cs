using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Desafio.API.ViewModels
{
    public class UpdatePessoaViewModel
    {
        [Required(ErrorMessage = "ID é obrigatório.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(300, ErrorMessage = "O nome da pessoa deve ter até 300 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório.")]
        [StringLength(11, ErrorMessage = "CPF deve conter 11 caracteres.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Idade é obrigatório.")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "ID da cidade é obrigatório.")]
        public int IdCidade { get; set; }

        [JsonIgnore]
        public CriarCidadeViewModel Cidade { get; set; }
    }
}
