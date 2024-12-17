using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContaFacil.Models
{
    public class Cliente : Pessoa
    {
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        public Conta Conta { get; private set; }

        public Cliente() { }

        public Cliente(string nome, string email, string telefone, Endereco endereco)
            : base(nome, email, telefone)
        {
            Endereco = endereco;
            Conta = new Conta(this);
        }
    }
}
