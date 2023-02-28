using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Entities.Juego
{
    public partial class Juego
    {
        public int IdJuego { get; set; }
        public int IdJugador { get; set; }
        public int Puntaje { get; set; }
        public DateTime FechaJuego { get; set; }

        public virtual Jugador IdJugadorNavigation { get; set; }
    }
}
