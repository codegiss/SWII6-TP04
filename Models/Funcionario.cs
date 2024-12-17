using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContaFacil.Models
{
    public class Funcionario
    {
        [Required(ErrorMessage = "O cargo é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O cargo pode ter no máximo 100 caracteres.")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "O salário é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O salário deve ser um valor positivo.")]
        public decimal Salario { get; set; }
    }
}
