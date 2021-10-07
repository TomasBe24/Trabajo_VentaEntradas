using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trabajo_VentaEntradas.Models
{
    public class Usuario
    {
        [Key]
        public string dni { get; set; }
        public string contrasenia { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        
    }
}
