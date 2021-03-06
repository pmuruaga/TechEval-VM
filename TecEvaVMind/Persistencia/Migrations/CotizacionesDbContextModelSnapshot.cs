﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

namespace Persistencia.Migrations
{
    [DbContext(typeof(CotizacionesDbContext))]
    partial class CotizacionesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Moneda", b =>
                {
                    b.Property<Guid>("MonedaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodigoMoneda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MonedaId");

                    b.ToTable("Moneda");

                    b.HasData(
                        new
                        {
                            MonedaId = new Guid("584ea53d-f22b-4767-a2c7-86f040155054"),
                            CodigoMoneda = "USD",
                            Nombre = "Dolar"
                        },
                        new
                        {
                            MonedaId = new Guid("5ffcf779-9fe2-4f66-8e50-2c851af3f48b"),
                            CodigoMoneda = "BRL",
                            Nombre = "Real"
                        });
                });

            modelBuilder.Entity("Dominio.Transaccion", b =>
                {
                    b.Property<Guid>("TransaccionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MonedaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("MontoCompra")
                        .HasColumnType("float");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TransaccionId");

                    b.ToTable("Transaccion");
                });

            modelBuilder.Entity("Dominio.Usuario", b =>
                {
                    b.Property<Guid>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DNI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            UsuarioId = new Guid("6fbe55b2-a3b8-40a7-b754-8bb1a58e62b4"),
                            Apellido = "Perez",
                            DNI = "32.343.198",
                            Nombre = "Pablo"
                        },
                        new
                        {
                            UsuarioId = new Guid("4758d74a-eac3-49a6-b5b3-d14fc2911ede"),
                            Apellido = "Avila",
                            DNI = "30.993.251",
                            Nombre = "Juan"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
