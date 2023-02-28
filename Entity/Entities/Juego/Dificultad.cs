using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Entities.Juego
{
    public partial class Dificultad
    {
        public Dificultad()
        {
            Penalizacions = new HashSet<Penalizacion>();
            Pregunta = new HashSet<Preguntum>();
        }

        public int IdDificultad { get; set; }
        public string Dificultad1 { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Penalizacion> Penalizacions { get; set; }
        public virtual ICollection<Preguntum> Pregunta { get; set; }
    }
}
