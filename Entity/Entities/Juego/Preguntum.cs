using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Entities.Juego
{
    public partial class Preguntum
    {
        public int IdPregunta { get; set; }
        public int IdDificultad { get; set; }
        public int IdCategoria { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public int Puntos { get; set; }
        public string Estado { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; }
        public virtual Dificultad IdDificultadNavigation { get; set; }
    }
}
