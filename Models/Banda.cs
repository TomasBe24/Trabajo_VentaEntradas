using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trabajo_VentaEntradas.Models
{
    public class Banda
    {

        [Key]
        public int id { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Foto")]
        public string foto { get; set; }

        [NotMapped]
        [DisplayName("Cargar archivo")]
        public IFormFile Imagefile { get; set; }
    }
}
