using System.ComponentModel.DataAnnotations;

namespace Desafio.API.ViewModels
{
    public class UpdateCidadeViewModel
    {
        [Required(ErrorMessage = "ID não pode ser vazio.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O nome da cidade deve ter até 200 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "UF é obrigatório.")]
        [StringLength(2, ErrorMessage = "UF deve conter 2 caracteres.")]
        public string UF { get; set; }
    }
}
