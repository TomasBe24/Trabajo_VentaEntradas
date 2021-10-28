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

        [DisplayName("Fecha")]
        public DateTime fecha { get; set; }
        public string banda { get; set; }
        public int precioCampo { get; set; }
        public int precioPlatea { get; set; }
        public int asientosPlatea { get; set; }
        public int asientosCampo { get; set; }
        
        [Display(Name = "Localidad")]
        public int idLocalidad { get; set; }
    }
}
