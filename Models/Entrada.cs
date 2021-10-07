using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabajo_VentaEntradas.Models
{
    public class Entrada
    {
        public int id { get; set; }
        public string seccion { get; set; }
        public int precio { get; set; }
        public int asiento { get; set; }
        public DateTime fecha { get; set; }
        public string dniUsuario{ get; set; }
        public int idShow { get; set; }
    }
}
