using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VentaJuegosUsados.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaJuegos()
        {
            ViewBag.Message = "Listado de juegos";

            return View();
        }

        public ActionResult PublicarJuego()
        {
            ViewBag.Message = "Vende tu juego";

            return View();
        }
    }
}