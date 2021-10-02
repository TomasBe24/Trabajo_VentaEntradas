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
    }
}
