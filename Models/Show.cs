using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace Trabajo_VentaEntradas.Models
{
    public class Show
    {
        public string fecha { get; set; }
        public int  horario { get; set; }
        public string banda { get; set; }
        public int precioCampo { get; set; }
        public int precioPlatea { get; set; }
        public ArrayList asientosPlatea { get; set; }
        public ArrayList asientosCampo { get; set; }

    }
}
