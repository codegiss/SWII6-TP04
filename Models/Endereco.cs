using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ContaFacil.Models
{
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [MaxLength(9, ErrorMessage = "O CEP pode ter no máximo 9 caracteres.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O número é obrigatório.")]
        [MaxLength(10, ErrorMessage = "O número pode ter no máximo 10 caracteres.")]
        public string Numero { get; set; }

        [MaxLength(20, ErrorMessage = "A referência pode ter no máximo 20 caracteres.")]
        public string Referencia { get; set; }

        public ICollection<Cliente> Clientes { get; set; }

        public Endereco() { }
        public Endereco(string cep, string numero, string referencia)
        {
            Cep = cep;
            Numero = numero;
            Referencia = referencia;
        }
    }
}
