using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContaFacil.Views.Home
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public bool LoginFailed { get; set; }

        public IActionResult OnPost()
        {
            // Simulando a autentica��o (substitua pela l�gica de autentica��o real)
            if (Username == "admin" && Password == "admin")
            {
                // Redireciona para a p�gina principal ap�s login bem-sucedido
                return RedirectToPage("/Home");
            }
            else
            {
                LoginFailed = true;
                return Page();
            }
        }
    }
}
