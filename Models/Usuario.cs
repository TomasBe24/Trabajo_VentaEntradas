﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabajo_VentaEntradas.Models
{
    public class Usuario
    {
        public string dni { get; set; }
        public string contrasenia { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Tarjeta tarjeta { get; set; }
        public Entrada entradasList { get; set; }
    }
}
