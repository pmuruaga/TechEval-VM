using Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Persistencia
{
    public class CotizacionesDbContext : DbContext
    {
        public CotizacionesDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Moneda>().HasData(
                new Moneda { MonedaId = Guid.NewGuid(), CodigoMoneda = "USD", Nombre = "Dolar" },
                new Moneda { MonedaId = Guid.NewGuid(), CodigoMoneda = "BRL", Nombre = "Real" }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { UsuarioId = Guid.NewGuid(), Nombre = "Pablo", Apellido = "Perez", DNI = "32.343.198" },
                new Usuario { UsuarioId = Guid.NewGuid(), Nombre = "Juan", Apellido = "Avila", DNI = "30.993.251" }
            );
        }

        public DbSet<Moneda> Moneda { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Transaccion> Transaccion { get; set; }
    }
}
