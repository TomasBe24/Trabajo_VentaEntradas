using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabajo_VentaEntradas.Models
{
    public class Entrada
    {
        public string seccion { get; set; }
        public int precio { get; set; }
        public int asiento { get; set; }
        public string fecha { get; set; }
        public int horario { get; set; }
        public string banda { get; set; }
    }
}
