using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Trabajo_VentaEntradas.Models
{
    public class Show
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Fecha y hora")]
        public DateTime fecha { get; set; }
        [DisplayName("Banda")]
        public int banda { get; set; }
        public int precioCampo { get; set; }
        public int precioPlatea { get; set; }
        [Display(Name ="Entrada")]
        public int asientosPlatea { get; set; }
        public int asientosCampo { get; set; }
        
        [Display(Name = "Localidad")]
        public int idLocalidad { get; set; }
    }
}
