using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Entities.Juego
{
    public partial class Categorium
    {
        public Categorium()
        {
            Pregunta = new HashSet<Preguntum>();
        }

        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Preguntum> Pregunta { get; set; }
    }
}
