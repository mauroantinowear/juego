using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Entities.Juego
{
    public partial class Penalizacion
    {
        public int IdPenalizacion { get; set; }
        public int IdDificultad { get; set; }
        public string Penalizacion1 { get; set; }
        public string Estado { get; set; }

        public virtual Dificultad IdDificultadNavigation { get; set; }
    }
}
