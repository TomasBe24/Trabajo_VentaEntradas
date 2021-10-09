using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trabajo_VentaEntradas.Models
{
    public class Entrada
    {
        [Key]
        public int id { get; set; }
        public string seccion { get; set; }
        public int precio { get; set; }
        public int asiento { get; set; }
        public DateTime fecha { get; set; }
        public string dniUsuario{ get; set; }
        [Display(Name = "Nombre del show")]
        public int idShow { get; set; }
    }
}
