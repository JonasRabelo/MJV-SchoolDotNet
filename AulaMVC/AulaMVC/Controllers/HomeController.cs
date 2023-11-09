using AulaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AulaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Usuario usuario = new Usuario();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string habilidade)
        {
            usuario.habilidades.Add(new Habilidades(habilidade));
            return View(usuario);
        }

        [HttpPost]
        public IActionResult ProcessandoFormulario(string hab)
        {
            usuario.habilidades.Add(new Habilidades(hab));
            

            return View("Index", usuario);
        }

        public IActionResult Privacy()
        {
            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario = new Usuario();

            for (int i = 0; i <= 9; i++)
            {
                usuario.Nome = "Jonas";
                usuario.SobreNome = " da Silva Rabelo";
                usuario.Email = "jonas@gmail.com";
                usuarios.Add(usuario);
            }

            return View(usuarios);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}