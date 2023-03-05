using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace juego.Models
{
    public class ErrorMessage
    {
        public int Estado { get; set; }
        public string Mensaje { get; set; }
        public Object Datos { get; set; }

        public ErrorMessage()
        {
            Estado = 0;
            Mensaje = "Ha Ocurrido un Error Inesperado, por favor intentelo más tarde!";
            Datos = null;
        }
    }
}
