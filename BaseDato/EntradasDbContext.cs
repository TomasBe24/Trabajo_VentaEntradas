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

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Tarjeta> Tarjeta { get; set; }
        public DbSet<Localidad> Localidad { get; set; }
        public DbSet<Show> Show { get; set; }
        public DbSet<Entrada> Entrada { get; set; }
        public DbSet<Banda> Banda { get; set; }
    }
}
