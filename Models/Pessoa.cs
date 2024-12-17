using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ContaFacil.Models
{
    public class Pessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(150, ErrorMessage = "O nome pode ter no máximo 150 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email fornecido não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "O telefone fornecido não é válido.")]
        public string Telefone { get; set; }
        protected Pessoa() { }
        protected Pessoa(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }
}
