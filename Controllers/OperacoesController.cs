using ContaFacil.Data;
using ContaFacil.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContaFacil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacoesController : ControllerBase
    {
        private readonly BankContext _context;

        public OperacoesController(BankContext context)
        {
            _context = context;
        }

        [HttpPost("transferir")]
        public async Task<IActionResult> Transferir(int contaOrigemId, int contaDestinoId, double valor)
        {
            var contaOrigem = await _context.Contas.FindAsync(contaOrigemId);
            var contaDestino = await _context.Contas.FindAsync(contaDestinoId);

            if (contaOrigem == null || contaDestino == null)
                return NotFound("Conta origem ou destino inválida.");

            if (!contaOrigem.VerificarSaldo(valor))
                return BadRequest("Saldo insuficiente!");

            contaOrigem.AlterarSaldo(-valor);
            contaDestino.AlterarSaldo(valor);

            var operacao = new Operacao(contaOrigem, contaDestino, valor, "Transferência");
            contaOrigem.AdicionarOperacao(operacao);

            await _context.SaveChangesAsync();
            return Ok("Transferência realizada com sucesso.");
        }
    }
}
