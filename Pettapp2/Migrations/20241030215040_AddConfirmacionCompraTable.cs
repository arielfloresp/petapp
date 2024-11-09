using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pettapp2.Migrations
{
    public partial class AddConfirmacionCompraTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfirmacionesCompra",
                columns: table => new
                {
                    ConfirmacionCompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BancoDestino = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroTransaccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MontoAbonado = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ComprobantePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmacionesCompra", x => x.ConfirmacionCompraId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfirmacionesCompra");
        }
    }
}
