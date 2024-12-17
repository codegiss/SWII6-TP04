using System.Diagnostics;
using ContaFacil.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContaFacil.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string usuarioId, string senha)
        {
            if (usuarioId == "admin" && senha == "1234")
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewData["Erro"] = "ID ou senha inválidos!";
                return View();
            }
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
