using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entities.Juego;
using DTO.List;
namespace Entity.IServices
{
    public interface IJuegoServices
    {
        List<Categorium> GetCategorias();
        List<Dificultad> GetDificultades();
        List<ListaPreguntas> GetPreguntas();
        Categorium GetCategoria(int id);
        Dificultad GetDificultad(int id);
        Preguntum GetPregunta(int id);
        bool AddCategoria(Categorium categoria);
        bool EditCategoria(Categorium categoria);
        bool AddDificultad(Dificultad dificultad);
        bool EditDificultad(Dificultad dificultad);
        bool AddPregunta(Preguntum pregunta);
        bool EditPregunta(Preguntum pregunta);
        List<Jugador> GetJugadores();
        Jugador GetJugador(int id);
        bool AddJugador(Jugador jugador);
        bool EditJugador(Jugador jugador);
        List<Penalizacion> GetPenalizaciones();
        Penalizacion GetPenalizacion(int id);
        bool AddPena(Penalizacion penalizacion);
        bool EditPena(Penalizacion penalizacion);
        List<Juego> GetJuegos();
        Juego GetJuego(int id);
        bool AddJuego(Juego juego);
        bool EditJuego(Juego juego);
    }
}
