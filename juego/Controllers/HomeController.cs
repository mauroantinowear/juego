using Entity.Entities.Juego;
using Entity.IServices;
using juego.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
            ViewData["categoria"] = _services.GetCategorias();
            return View();
        }
        public JsonResult AddCat(Categorium cat)
        {
            ErrorMessage er = new ErrorMessage();
            if (cat.IdCategoria > 0)
            {
                if (_services.EditCategoria(cat))
                {
                    er.Estado = 1;
                    er.Mensaje = $"Se ha Modificado la Categoría: [{cat.Categoria}] con éxito!";
                }
            }
            else
            {
                if (_services.AddCategoria(cat))
                {
                    er.Estado = 1;
                    er.Mensaje = $"Se ha Agregado la Categoría: [{cat.Categoria}] con éxito!";
                }
            }
            return Json(JsonConvert.SerializeObject(er));
        }
        public IActionResult Dificultad()
        {
            ViewData["Title"] = "Nivel";
            ViewData["dificultad"] = _services.GetDificultades();
            return View();
        }
        public JsonResult AddDificultad(Dificultad dificultad)
        {
            ErrorMessage er = new ErrorMessage();
            if (dificultad.IdDificultad > 0)
            {
                if (_services.EditDificultad(dificultad))
                {
                    er.Estado = 1;
                    er.Mensaje = $"Se ha Modificado la Dificultad: [{dificultad.Dificultad1}] con éxito!";
                }
            }
            else
            {
                if (_services.AddDificultad(dificultad))
                {
                    er.Estado = 1;
                    er.Mensaje = $"Se ha Agregado la Dificultad: [{dificultad.Dificultad1}] con éxito!";
                }
            }
            return Json(JsonConvert.SerializeObject(er));
        }
        public IActionResult Castigos()
        {
            ViewData["Title"] = "Castigos";
            ViewData["dificultad"] = _services.GetDificultades();
            ViewData["castigos"] = _services.GetPenalizaciones();
            return View();
        }
        public JsonResult AddCastigo(Penalizacion penalizacion)
        {
            ErrorMessage er = new ErrorMessage();
            if (penalizacion.IdPenalizacion > 0)
            {
                if (_services.EditPena(penalizacion))
                {
                    er.Estado = 1;
                    er.Mensaje = $"Se Modificó el Castigo: {penalizacion.Penalizacion1} con éxito!";
                }
            }
            else {
                if (_services.AddPena(penalizacion))
                {
                    er.Estado = 1;
                    er.Mensaje = $"Se Agregó el Castigo: {penalizacion.Penalizacion1} con éxito!";
                }
            }
            return Json(JsonConvert.SerializeObject(er));
        }
        public IActionResult Preguntas()
        {
            ViewData["Title"] = "Preguntas";
            ViewData["dificultad"] = _services.GetDificultades();
            ViewData["categoria"] = _services.GetCategorias();
            ViewData["preguntas"] = _services.GetPreguntas();
            return View();
        }
        public JsonResult AddPregunta(Preguntum preguntum)
        {
            ErrorMessage er = new ErrorMessage();
            if (preguntum.IdPregunta > 0)
            {
                if (_services.EditPregunta(preguntum))
                {
                    er.Estado = 1;
                    er.Mensaje = $"Se Modificó la Pregunta N°: {preguntum.IdPregunta} con éxito!";
                }
            }
            else
            {
                if (_services.AddPregunta(preguntum))
                {
                    er.Estado = 1;
                    er.Mensaje = $"Se Agregó la Pregunta N°: {preguntum.IdPregunta} con éxito!";
                }
            }
            return Json(JsonConvert.SerializeObject(er));
        }
        public IActionResult Jugadores()
        {
            ViewData["Title"] = "Jugadores";
            ViewData["jugadores"] = _services.GetJugadores();
            return View();
        }
        public JsonResult AddPlayer(Jugador jugador)
        {
            ErrorMessage er = new ErrorMessage();
            if (jugador.IdJugador > 0)
            {
                if (_services.EditJugador(jugador))
                {
                    er.Estado = 1;
                    er.Mensaje = $"Se Modificó el Jugador: {jugador.Nombre} con éxito!";
                }
            }
            else
            {
                if (_services.AddJugador(jugador))
                {
                    er.Estado = 1;
                    er.Mensaje = $"Se Agregó el Jugador: {jugador.Nombre} con éxito!";
                }
            }
            return Json(JsonConvert.SerializeObject(er));
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
