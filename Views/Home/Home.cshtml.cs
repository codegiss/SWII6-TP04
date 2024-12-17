using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContaFacil.Models;
using System.Collections.Generic;
using System.Linq;
using ContaFacil.Data;

namespace ContaFacil.Views.Home
{
    public class HomeModel : PageModel
    {
        private readonly BankContext _context;

        public HomeModel(BankContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Nome { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Telefone { get; set; }

        public List<Cliente> Clientes { get; set; }

        public void OnGet()
        {
            Clientes = _context.Clientes.ToList();
        }

        public IActionResult OnPost()
        {
            var cliente = new Cliente { Nome = Nome, Email = Email, Telefone = Telefone };
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return RedirectToPage();
        }
    }
}
