using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB.Models;
using PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB;

namespace PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB.Context
{
    public class InmobiliariaDatabaseContext : DbContext
    {
        public InmobiliariaDatabaseContext(DbContextOptions<InmobiliariaDatabaseContext> options) : base(options)
        {
        }

        //Mapeo una lista de usuarios para que EF genere una tabla de usuarios

        public DbSet<Usuario> Usuarios { get; set; }

       
        //Mapeo una lista de propiedades en alquiler para que EF genere una tabla de propiedades en alquiler

        public DbSet<PropiedadVenta> PropiedadVenta { get; set; }

        //Mapeo una lista de propiedades en venta para que EF genere una tabla de propiedades en venta

        public DbSet<PropiedadAlquiler> PropiedadAlquiler { get; set; }
    }
}
