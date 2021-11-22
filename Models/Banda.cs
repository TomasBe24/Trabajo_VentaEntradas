using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trabajo_VentaEntradas.Models
{
    public class Banda
    {

        [Key]
        public int id { get; set; }

        public string nombre { get; set; }

        public string foto { get; set; }
    }
}
