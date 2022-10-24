using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB.Models;

namespace PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB.Context
{
    public class InmobiliariaDatabaseContext : DbContext
    {
        public InmobiliariaDatabaseContext(DbContextOptions<InmobiliariaDatabaseContext> options) : base(options)
        {
        }

        //Mapeo una lista de usuarios
        // para que EF genere una tabla de usuarios

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
