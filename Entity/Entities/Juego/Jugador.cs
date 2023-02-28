using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Entities.Juego
{
    public partial class Jugador
    {
        public Jugador()
        {
            Juegos = new HashSet<Juego>();
        }

        public int IdJugador { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Juego> Juegos { get; set; }
    }
}
