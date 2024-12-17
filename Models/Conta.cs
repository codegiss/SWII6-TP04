using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContaFacil.Models
{
    public class Conta
    {
        [Key]
        public int Id { get; set; }
        public Cliente Cliente { get; private set; }
        public int ClienteId { get; set; }

        public double Saldo { get; set; }

        [NotMapped]
        public ICollection<Operacao> HistoricoOperacao { get; set; } = new List<Operacao>();
        public Conta() { }

        public Conta(Cliente cliente)
        {
            Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
            Saldo = 0.0;
        }

        public bool VerificarSaldo(double valor)
        {
            return Saldo >= valor;
        }

        public void AdicionarOperacao(Operacao operacao)
        {
            if (operacao == null) throw new ArgumentNullException(nameof(operacao));
            HistoricoOperacao.Add(operacao);
        }

        public void AlterarSaldo(double valor)
        {
            Saldo += valor;
        }
    }
}
