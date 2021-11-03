using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabajo_VentaEntradas.ViewModels
{
    public class ConfirmarCompraVM
    {
        public int idShow { get; set; }
        public DateTime fecha { get; set; }
        public string banda { get; set; }
        public int precioCampo { get; set; }
        public int precioPlatea { get; set; }
        public int asientosPlatea { get; set; }
        public int asientosCampo { get; set; }
        public int idLocalidad { get; set; }
        public string localidad { get; set; }
        public int CantidadEntradas { get; set; }

    }
}
