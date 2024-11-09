using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pettapp2.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__F92302D1E14BB533", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RolID = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__2B3DE798DED20E77", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol",
                        column: x => x.RolID,
                        principalTable: "Roles",
                        principalColumn: "RolID");
                });

            migrationBuilder.CreateTable(
                name: "Accesorios",
                columns: table => new
                {
                    AccesorioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    VendedorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Accesori__4BCD4EA9B26B191C", x => x.AccesorioID);
                    table.ForeignKey(
                        name: "FK_Accesorio_Usuario",
                        column: x => x.VendedorID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateTable(
                name: "CarritoDeCompras",
                columns: table => new
                {
                    CarritoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CarritoD__778D580BB115B576", x => x.CarritoID);
                    table.ForeignKey(
                        name: "FK_Carrito_Usuario",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateTable(
                name: "Refugios",
                columns: table => new
                {
                    RefugioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Refugios__AD4F9C4244E2CBE1", x => x.RefugioID);
                    table.ForeignKey(
                        name: "FK_Refugio_Usuario",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateTable(
                name: "CarritoAccesorios",
                columns: table => new
                {
                    CarritoAccesorioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarritoID = table.Column<int>(type: "int", nullable: false),
                    AccesorioID = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CarritoA__ABF0DCC17C1BC6E0", x => x.CarritoAccesorioID);
                    table.ForeignKey(
                        name: "FK_CarritoAccesorio_Accesorio",
                        column: x => x.AccesorioID,
                        principalTable: "Accesorios",
                        principalColumn: "AccesorioID");
                    table.ForeignKey(
                        name: "FK_CarritoAccesorio_Carrito",
                        column: x => x.CarritoID,
                        principalTable: "CarritoDeCompras",
                        principalColumn: "CarritoID");
                });

            migrationBuilder.CreateTable(
                name: "Donaciones",
                columns: table => new
                {
                    DonacionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    RefugioID = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FechaDonacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Donacion__9F5DEEE7368907D4", x => x.DonacionID);
                    table.ForeignKey(
                        name: "FK_Donacion_Refugio",
                        column: x => x.RefugioID,
                        principalTable: "Refugios",
                        principalColumn: "RefugioID");
                    table.ForeignKey(
                        name: "FK_Donacion_Usuario",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateTable(
                name: "Mascotas",
                columns: table => new
                {
                    MascotaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Raza = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EstadoAdopcion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Disponible"),
                    RefugioID = table.Column<int>(type: "int", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mascotas__8DBC411CC52B78B1", x => x.MascotaID);
                    table.ForeignKey(
                        name: "FK_Mascota_Refugio",
                        column: x => x.RefugioID,
                        principalTable: "Refugios",
                        principalColumn: "RefugioID");
                });

            migrationBuilder.CreateTable(
                name: "Adopciones",
                columns: table => new
                {
                    AdopcionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    MascotaID = table.Column<int>(type: "int", nullable: false),
                    FechaAdopcion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Adopcion__AAEE3F678C3CC459", x => x.AdopcionID);
                    table.ForeignKey(
                        name: "FK_Adopcion_Mascota",
                        column: x => x.MascotaID,
                        principalTable: "Mascotas",
                        principalColumn: "MascotaID");
                    table.ForeignKey(
                        name: "FK_Adopcion_Usuario",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accesorios_VendedorID",
                table: "Accesorios",
                column: "VendedorID");

            migrationBuilder.CreateIndex(
                name: "IX_Adopciones_MascotaID",
                table: "Adopciones",
                column: "MascotaID");

            migrationBuilder.CreateIndex(
                name: "UC_Usuario_Mascota",
                table: "Adopciones",
                columns: new[] { "UsuarioID", "MascotaID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarritoAccesorios_AccesorioID",
                table: "CarritoAccesorios",
                column: "AccesorioID");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoAccesorios_CarritoID",
                table: "CarritoAccesorios",
                column: "CarritoID");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoDeCompras_UsuarioID",
                table: "CarritoDeCompras",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Donaciones_RefugioID",
                table: "Donaciones",
                column: "RefugioID");

            migrationBuilder.CreateIndex(
                name: "IX_Donaciones_UsuarioID",
                table: "Donaciones",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_RefugioID",
                table: "Mascotas",
                column: "RefugioID");

            migrationBuilder.CreateIndex(
                name: "IX_Refugios_UsuarioID",
                table: "Refugios",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolID",
                table: "Usuarios",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "UQ__Usuarios__A9D10534F50A25DF",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adopciones");

            migrationBuilder.DropTable(
                name: "CarritoAccesorios");

            migrationBuilder.DropTable(
                name: "Donaciones");

            migrationBuilder.DropTable(
                name: "Mascotas");

            migrationBuilder.DropTable(
                name: "Accesorios");

            migrationBuilder.DropTable(
                name: "CarritoDeCompras");

            migrationBuilder.DropTable(
                name: "Refugios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
