using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trabajo_VentaEntradas.Models
{
    public abstract class Usuario
    {
        [Key]
        [Required(ErrorMessage = "Debe Ingresar su DNI")]
        [Range(1, 99999999999)]
        [Display(Name = "DNI")]
        public string dni { get; set; }

        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [Display(Name = "Contraseña")]
        
        public string contrasenia { get; set; }

        [Required(ErrorMessage = "Debe Ingresar su nombre")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Debe Ingresar su apellido")]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }
        public abstract Rol Rol { get; }

    }
}
