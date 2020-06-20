using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moneda",
                columns: table => new
                {
                    MonedaId = table.Column<Guid>(nullable: false),
                    CodigoMoneda = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moneda", x => x.MonedaId);
                });

            migrationBuilder.CreateTable(
                name: "Transaccion",
                columns: table => new
                {
                    TransaccionId = table.Column<Guid>(nullable: false),
                    FechaCompra = table.Column<DateTime>(nullable: false),
                    MonedaId = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    MontoCompra = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaccion", x => x.TransaccionId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    DNI = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.InsertData(
                table: "Moneda",
                columns: new[] { "MonedaId", "CodigoMoneda", "Nombre" },
                values: new object[,]
                {
                    { new Guid("584ea53d-f22b-4767-a2c7-86f040155054"), "USD", "Dolar" },
                    { new Guid("5ffcf779-9fe2-4f66-8e50-2c851af3f48b"), "BRL", "Real" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "UsuarioId", "Apellido", "DNI", "Nombre" },
                values: new object[,]
                {
                    { new Guid("6fbe55b2-a3b8-40a7-b754-8bb1a58e62b4"), "Perez", "32.343.198", "Pablo" },
                    { new Guid("4758d74a-eac3-49a6-b5b3-d14fc2911ede"), "Avila", "30.993.251", "Juan" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moneda");

            migrationBuilder.DropTable(
                name: "Transaccion");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
