using Microsoft.AspNetCore.Mvc;
using SitioWebPwa.Models;
using SitioWebPwa.ViewModels;
using System.Diagnostics;

namespace SitioWebPwa.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            var valores = ObtenerValores().Take(3).ToList();
            var modelo = new ValoresVM()
            {
                valores = valores
            };
            return View(modelo);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private List<Valores> ObtenerValores()
        {
            return new List<Valores>
            {
              new Valores
              {
                  Titulo="Deporte como Escuela",
                  Imagen="/img/123Deca.png",
                  Detalle="Escuela de futbol y patin, las actividades que nos forman la pasion y nos mueven el alma."
              },
              new Valores
              {
                  Titulo="La Familia Primero",
                  Imagen="/img/EquipoDeca.png",
                  Detalle="El buffet donde se debaten los partidos, mates compartidos en la tribuna y los eventos del club"
              },
              new Valores
              {
                  Titulo="Sentido de pertenencia",
                  Imagen="img/FemeninoDeca.png",
                  Detalle="Orgullosos de nuestros colores y de nuestra gente. Aca jugamos todos"
              }
            };
        }
    }
}
