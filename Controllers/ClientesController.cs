using ContaFacil.Data;
using ContaFacil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContaFacil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly BankContext _context;

        public ClientesController(BankContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> CreateCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes
                                        .Include(c => c.Conta)
                                        .ThenInclude(c => c.HistoricoOperacao)
                                        .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
                return NotFound();

            return cliente;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
                return BadRequest();

            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound();

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return Ok("Cliente deletado com sucesso!");
        }
    }
}
