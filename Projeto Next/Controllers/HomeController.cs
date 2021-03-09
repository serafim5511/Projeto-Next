using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_Next.Models;
using Projeto_Next.Request;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Next.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Logado()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Entrar()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(DadosPessoais dados)
        {
            Client.POST("https://localhost:44332/api/", "DadosPessoais", dados, null);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Logar(string email , string senha)
        {
            var json = Client.GET("https://localhost:44332/api/", "DadosPessoais/login?email="+email+"&senha="+senha , new Dictionary<string, string>() , null);
            var dados = json.Content.ReadAsStringAsync();
            if (json.StatusCode.ToString() =="OK") 
            { 
                return RedirectToAction("Logado",dados);
            }
            ViewBag.autenticar = "Usuario ou senha errado.";
            return View("Entrar");
        }

    }
}
