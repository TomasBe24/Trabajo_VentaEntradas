using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Trabajo_VentaEntradas.Models;

namespace Trabajo_VentaEntradas.BaseDato
{
    public class EntradasDbContext : DbContext
    {
        public EntradasDbContext(DbContextOptions opciones) : base(opciones)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Trabajo_VentaEntradas.Models.Tarjeta> Tarjeta { get; set; }

        public DbSet<Trabajo_VentaEntradas.Models.Localidad> Localidad { get; set; }

        public DbSet<Trabajo_VentaEntradas.Models.Show> Show { get; set; }

        public DbSet<Trabajo_VentaEntradas.Models.Entrada> Entrada { get; set; }
    }
}
