using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.List
{
    public class ListaPreguntas
    {
        public int IdPregunta { get; set; }
        public int IdDificultad { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public string Dificultad1 { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public int Puntos { get; set; }
        public string Estado { get; set; }
    }
}
