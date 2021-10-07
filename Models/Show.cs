using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace Trabajo_VentaEntradas.Models
{
    public class Show
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string banda { get; set; }
        public int precioCampo { get; set; }
        public int precioPlatea { get; set; }
        public int asientosPlatea { get; set; }
        public int asientosCampo { get; set; }
        public int idLocalidad { get; set; }
    }
}
