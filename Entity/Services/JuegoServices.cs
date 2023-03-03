using DTO.List;
using Entity.Context;
using Entity.Entities.Juego;
using Entity.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Services
{
    public class JuegoServices : IJuegoServices
    {
        private readonly IConfiguration _configuration;
        private readonly JuegoContext _juegoContext;
        private readonly ILogger<JuegoServices> _logger;

        public JuegoServices(IConfiguration configuration, JuegoContext juegoContext, ILogger<JuegoServices> logger)
        {
            _configuration = configuration;
            _juegoContext = juegoContext;
            _logger = logger;
        }
        public bool AddCategoria(Categorium categoria)
        {
            int Id = _juegoContext.Categoria.DefaultIfEmpty().Max(c => c == null ? 0 : c.IdCategoria) + 1;
            categoria.IdCategoria = Id;
            _juegoContext.Categoria.Add(categoria);
            return _juegoContext.SaveChanges() > 0;
        }

        public bool AddDificultad(Dificultad dificultad)
        {
            int Id = _juegoContext.Dificultads.DefaultIfEmpty().Max(d => d == null ? 0 : d.IdDificultad) + 1;
            dificultad.IdDificultad = Id;
            _juegoContext.Dificultads.Add(dificultad);
            return _juegoContext.SaveChanges() > 0;
        }

        public bool AddJuego(Juego juego)
        {
            int Id = _juegoContext.Juegos.DefaultIfEmpty().Max(j => j == null ? 0 : j.IdJuego) + 1;
            juego.IdJuego = Id;
            _juegoContext.Juegos.Add(juego);
            return _juegoContext.SaveChanges() > 0;
        }

        public bool AddJugador(Jugador jugador)
        {
            int Id = _juegoContext.Jugadors.DefaultIfEmpty().Max(c => c == null ? 0 : c.IdJugador) + 1;
            jugador.IdJugador = Id;
            _juegoContext.Jugadors.Add(jugador);
            return _juegoContext.SaveChanges() > 0;
        }

        public bool AddPena(Penalizacion penalizacion)
        {
            int Id = _juegoContext.Penalizacions.DefaultIfEmpty().Max(c => c == null ? 0 : c.IdPenalizacion) + 1;
            penalizacion.IdPenalizacion = Id;
            _juegoContext.Penalizacions.Add(penalizacion);
            return _juegoContext.SaveChanges() > 0;
        }

        public bool AddPregunta(Preguntum pregunta)
        {
            int Id = _juegoContext.Pregunta.DefaultIfEmpty().Max(c => c == null ? 0 : c.IdPregunta) + 1;
            pregunta.IdPregunta = Id;
            _juegoContext.Pregunta.Add(pregunta);
            return _juegoContext.SaveChanges() > 0;
        }

        public bool EditCategoria(Categorium categoria)
        {
            _juegoContext.Categoria.Update(categoria);
            return _juegoContext.SaveChanges() > 0;
        }

        public bool EditDificultad(Dificultad dificultad)
        {
            _juegoContext.Dificultads.Update(dificultad);
            return _juegoContext.SaveChanges() > 0;
        }

        public bool EditJuego(Juego juego)
        {
            _juegoContext.Juegos.Update(juego);
            return _juegoContext.SaveChanges() > 0;
        }

        public bool EditJugador(Jugador jugador)
        {
            _juegoContext.Jugadors.Update(jugador);
            return _juegoContext.SaveChanges() > 0;
        }

        public bool EditPena(Penalizacion penalizacion)
        {
            _juegoContext.Penalizacions.Update(penalizacion);
            return _juegoContext.SaveChanges() > 0;
        }

        public bool EditPregunta(Preguntum pregunta)
        {
            _juegoContext.Pregunta.Update(pregunta);
            return _juegoContext.SaveChanges() > 0;
        }

        public Categorium GetCategoria(int id)
        {
            return _juegoContext.Categoria.Find(id);
        }

        public List<Categorium> GetCategorias()
        {
            return _juegoContext.Categoria.ToList();
        }

        public Dificultad GetDificultad(int id)
        {
            return _juegoContext.Dificultads.Find(id);
        }

        public List<Dificultad> GetDificultades()
        {
            return _juegoContext.Dificultads.ToList();
        }

        public Juego GetJuego(int id)
        {
            return _juegoContext.Juegos.Find(id);
        }

        public List<Juego> GetJuegos()
        {
            return _juegoContext.Juegos.ToList();
        }

        public Jugador GetJugador(int id)
        {
            return _juegoContext.Jugadors.Find(id);
        }

        public List<Jugador> GetJugadores()
        {
            return _juegoContext.Jugadors.ToList();
        }

        public Penalizacion GetPenalizacion(int id)
        {
            return _juegoContext.Penalizacions.Find(id);
        }

        public List<Penalizacion> GetPenalizaciones()
        {
            return _juegoContext.Penalizacions.ToList();
        }

        public Preguntum GetPregunta(int id)
        {
            return _juegoContext.Pregunta.Find(id);
        }

        public List<ListaPreguntas> GetPreguntas()
        {
            return (from p in _juegoContext.Pregunta
                    join c in _juegoContext.Categoria on p.IdCategoria equals c.IdCategoria
                    join d in _juegoContext.Dificultads on p.IdDificultad equals d.IdDificultad
                    select new ListaPreguntas {
                        IdPregunta=p.IdPregunta,
                        IdCategoria=p.IdCategoria,
                        IdDificultad=p.IdDificultad,
                        Categoria=c.Categoria,
                        Dificultad1=d.Dificultad1,
                        Pregunta=p.Pregunta,
                        Respuesta=p.Respuesta,
                        Puntos=p.Puntos,
                        Estado=p.Estado
                    }).ToList();
        }
    }
}
