using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabajo_VentaEntradas.Models
{
    public class Cliente : Usuario
    {
        public override Rol Rol => Rol.Cliente;
    }
}
