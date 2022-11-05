using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd_Bd.Models
{
    public class Maestros
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }

        public string matricula { get; set; }

        public int Edad { get; set; }

        public int sueldo { get; set; }
    }
}
