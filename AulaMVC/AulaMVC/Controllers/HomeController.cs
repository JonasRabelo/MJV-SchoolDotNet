using AulaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace AulaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Usuario usuario;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            usuario = new Usuario();
        }


        public IActionResult Index()
        {
            usuario.habilidades = LerDados();
            return View("Index", usuario);
        }

        [HttpPost]
        public IActionResult ProcessandoFormulario(string habilidade)
        {
            _logger.LogInformation($"Habilidade recebida: {habilidade} Tamanho; {usuario.habilidades.Count()}");
            usuario.habilidades.Add(new Habilidades(habilidade));

            SalvarDados(usuario.habilidades);

            return RedirectToAction("Index", usuario);
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

        private List<Habilidades> LerDados()
        {
            List<Habilidades> hab = new List<Habilidades>();
            string[] dados = System.IO.File.ReadAllText(Path.Combine(Directory.GetParent(Environment.CurrentDirectory)!.FullName, "db.txt")).Replace("\n", "").Split(" ? ");
            Console.WriteLine("AQUI:" + dados.ToString());
            if (dados != null)
            {
                Array.Resize(ref dados, dados.Length - 1);
                foreach (string dado in dados)
                {
                    hab.Add(new Habilidades(dado));
                }

            }
            return hab;

        }

        public void SalvarDados(List<Habilidades> dados)
        {
            foreach (var d in dados)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(Directory.GetParent(Environment.CurrentDirectory)!.FullName, "db.txt"), true))
                {
                    // Escreve a nova habilidade no final do arquivo
                    sw.WriteLine(d.Nome + "?");
                }
            }
        }
    }
}