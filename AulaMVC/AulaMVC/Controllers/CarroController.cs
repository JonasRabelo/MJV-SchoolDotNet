using AulaMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AulaMVC.Controllers
{
    public class CarroController : Controller
    {
        public IActionResult Index()
        {
            List<CarroModel> listaDeCarros = new List<CarroModel>
            {
                new CarroModel { Modelo = "Creta", Ano = 2023 },
                new CarroModel { Modelo = "Gol", Ano = 2023 },
                new CarroModel { Modelo = "Amaroc", Ano = 2017 }
            };

            // Certificando-se de que a lista não é nula
            if (listaDeCarros == null)
            {
                listaDeCarros = new List<CarroModel>();
            }
            return View(listaDeCarros);
        }
    }
}
