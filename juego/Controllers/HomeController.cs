using Entity.IServices;
using juego.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace juego.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJuegoServices _services;

        public HomeController(ILogger<HomeController> logger, IJuegoServices services)
        {
            _logger = logger;
            _services = services;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categorias()
        {
            ViewData["Title"] = "Categoria";
            return View();
        }
        public IActionResult Dificultad()
        {
            return View();
        }
        public IActionResult Penalizacion()
        {
            return View();
        }
        public IActionResult Preguntas()
        {
            return View();
        }
        public IActionResult Jugadores()
        {
            return View();
        }
        public IActionResult Game()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
