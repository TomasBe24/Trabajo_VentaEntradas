﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace Trabajo_VentaEntradas.Models
{
    public class Localidad
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public int cantCampo { get; set; }
        public int cantPlatea { get; set; }

    }
}
