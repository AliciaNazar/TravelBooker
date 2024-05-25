using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBookerApi.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Butacas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Butacas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriasButacas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasButacas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colectivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalButacas = table.Column<int>(type: "int", nullable: false),
                    Completo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colectivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreLocalidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DniUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MayorDeEdad = table.Column<bool>(type: "bit", nullable: false),
                    IdButaca = table.Column<int>(type: "int", nullable: false),
                    IdViaje = table.Column<int>(type: "int", nullable: false),
                    PrecioTotal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Viajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLocalidadOrigen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdLocalidadDestino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaYHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    ButacasReservadas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdColectivo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Butacas");

            migrationBuilder.DropTable(
                name: "CategoriasButacas");

            migrationBuilder.DropTable(
                name: "Colectivos");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Viajes");
        }
    }
}
