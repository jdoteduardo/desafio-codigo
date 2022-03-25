using System.ComponentModel.DataAnnotations;

namespace Desafio.API.ViewModels
{
    public class CriarCidadeViewModel
    {
        [Required]
        [MaxLength(200, ErrorMessage = "O nome da cidade deve ter até 200 caracteres.")]
        public string Nome { get; set; }

        [Required]
        [StringLength(2, ErrorMessage = "UF deve conter 2 caracteres.")]
        public string UF { get; set; }
    }
}
