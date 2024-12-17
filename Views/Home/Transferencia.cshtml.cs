using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContaFacil.Models;
using System.Linq;
using ContaFacil.Data;

namespace ContaFacil.Views.Home
{
    public class TransferenciaModel : PageModel
    {
        private readonly BankContext _context;
        public TransferenciaModel(BankContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int ContaOrigemId { get; set; }
        [BindProperty]
        public int ContaDestinoId { get; set; }
        [BindProperty]
        public double Valor { get; set; }

        public IActionResult OnPost()
        {
            var contaOrigem = _context.Contas.FirstOrDefault(c => c.Id == ContaOrigemId);
            var contaDestino = _context.Contas.FirstOrDefault(c => c.Id == ContaDestinoId);

            if (contaOrigem != null && contaDestino != null && contaOrigem.Saldo >= Valor)
            {
                contaOrigem.Saldo -= Valor;
                contaDestino.Saldo += Valor;

                var operacaoOrigem = new Operacao
                {
                    ContaOrigemId = ContaOrigemId,
                    ContaDestinoId = ContaDestinoId,
                    Valor = Valor,
                    TipoOperacao = "Transferência"
                };
                _context.Operacoes.Add(operacaoOrigem);
                _context.SaveChanges();

                return RedirectToPage("/Home");
            }

            return Page();
        }
    }
}
