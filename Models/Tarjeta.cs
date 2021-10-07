using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trabajo_VentaEntradas.Models
{
    public class Tarjeta
    {
        [Key]
        public string numero { get; set; }
        public string vencimiento { get; set; }
        public string pin { get; set; }
        public string titular { get; set; }
        public string dniTitular{ get; set; }
    }
}
