using System.ComponentModel.DataAnnotations;

namespace ContaFacil.Models
{
    public class Operacao
    {
        [Key]
        public int Id { get; set; }

        public int ContaOrigemId { get; set; }
        public Conta ContaOrigem { get; set; }
        public int ContaDestinoId { get; set; }
        public Conta ContaDestino { get; set; }

        [Required(ErrorMessage = "O valor da operação é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "O tipo de operação é obrigatório.")]
        [MaxLength(10, ErrorMessage = "O tipo da operação deve ter no máximo 10 caracteres.")]
        public string TipoOperacao { get; set; }
        public DateTime DataOperacao { get; private set; } = DateTime.Now;

        public Operacao() { }
        public Operacao(Conta origem, Conta destino, double valor, string tipo)
        {
            ContaOrigem = origem ?? throw new ArgumentNullException(nameof(origem));
            ContaDestino = destino ?? throw new ArgumentNullException(nameof(destino));
            Valor = valor;
            TipoOperacao = tipo;
        }
    }
}
