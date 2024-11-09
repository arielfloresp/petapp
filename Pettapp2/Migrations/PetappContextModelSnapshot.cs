﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pettapp2.Models;

#nullable disable

namespace Pettapp2.Migrations
{
    [DbContext(typeof(PetappContext))]
    partial class PetappContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pettapp2.Models.Accesorio", b =>
                {
                    b.Property<int>("AccesorioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AccesorioID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccesorioId"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("VendedorId")
                        .HasColumnType("int")
                        .HasColumnName("VendedorID");

                    b.HasKey("AccesorioId")
                        .HasName("PK__Accesori__4BCD4EA9B26B191C");

                    b.HasIndex("VendedorId");

                    b.ToTable("Accesorios");
                });

            modelBuilder.Entity("Pettapp2.Models.Adopcione", b =>
                {
                    b.Property<int>("AdopcionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AdopcionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdopcionId"));

                    b.Property<DateTime?>("FechaAdopcion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("MascotaId")
                        .HasColumnType("int")
                        .HasColumnName("MascotaID");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioID");

                    b.HasKey("AdopcionId")
                        .HasName("PK__Adopcion__AAEE3F678C3CC459");

                    b.HasIndex("MascotaId");

                    b.HasIndex(new[] { "UsuarioId", "MascotaId" }, "UC_Usuario_Mascota")
                        .IsUnique();

                    b.ToTable("Adopciones");
                });

            modelBuilder.Entity("Pettapp2.Models.CarritoAccesorio", b =>
                {
                    b.Property<int>("CarritoAccesorioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CarritoAccesorioID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarritoAccesorioId"));

                    b.Property<int>("AccesorioId")
                        .HasColumnType("int")
                        .HasColumnName("AccesorioID");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CarritoId")
                        .HasColumnType("int")
                        .HasColumnName("CarritoID");

                    b.HasKey("CarritoAccesorioId")
                        .HasName("PK__CarritoA__ABF0DCC17C1BC6E0");

                    b.HasIndex("AccesorioId");

                    b.HasIndex("CarritoId");

                    b.ToTable("CarritoAccesorios");
                });

            modelBuilder.Entity("Pettapp2.Models.CarritoDeCompra", b =>
                {
                    b.Property<int>("CarritoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CarritoID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarritoId"));

                    b.Property<decimal?>("Total")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValue(0m);

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioID");

                    b.HasKey("CarritoId")
                        .HasName("PK__CarritoD__778D580BB115B576");

                    b.HasIndex("UsuarioId");

                    b.ToTable("CarritoDeCompras");
                });

            modelBuilder.Entity("Pettapp2.Models.ConfirmacionCompra", b =>
                {
                    b.Property<int>("ConfirmacionCompraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConfirmacionCompraId"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("BancoDestino")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ComprobantePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("EnvioCompletado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<decimal>("MontoAbonado")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NumeroTransaccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("PagoValidado")
                        .HasColumnType("bit");

                    b.HasKey("ConfirmacionCompraId");

                    b.ToTable("ConfirmacionesCompra");
                });

            modelBuilder.Entity("Pettapp2.Models.Donacione", b =>
                {
                    b.Property<int>("DonacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DonacionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonacionId"));

                    b.Property<DateTime?>("FechaDonacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("RefugioId")
                        .HasColumnType("int")
                        .HasColumnName("RefugioID");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioID");

                    b.HasKey("DonacionId")
                        .HasName("PK__Donacion__9F5DEEE7368907D4");

                    b.HasIndex("RefugioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Donaciones");
                });

            modelBuilder.Entity("Pettapp2.Models.Mascota", b =>
                {
                    b.Property<int>("MascotaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MascotaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MascotaId"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("EstadoAdopcion")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValue("Disponible");

                    b.Property<string>("ImagenUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Raza")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RefugioId")
                        .HasColumnType("int")
                        .HasColumnName("RefugioID");

                    b.Property<string>("Sexo")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("MascotaId")
                        .HasName("PK__Mascotas__8DBC411CC52B78B1");

                    b.HasIndex("RefugioId");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("Pettapp2.Models.Refugio", b =>
                {
                    b.Property<int>("RefugioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RefugioID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RefugioId"));

                    b.Property<string>("Direccion")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioID");

                    b.HasKey("RefugioId")
                        .HasName("PK__Refugios__AD4F9C4244E2CBE1");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Refugios");
                });

            modelBuilder.Entity("Pettapp2.Models.Role", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RolID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RolId")
                        .HasName("PK__Roles__F92302D1E14BB533");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Pettapp2.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UsuarioID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RolId")
                        .HasColumnType("int")
                        .HasColumnName("RolID");

                    b.HasKey("UsuarioId")
                        .HasName("PK__Usuarios__2B3DE798DED20E77");

                    b.HasIndex("RolId");

                    b.HasIndex(new[] { "Email" }, "UQ__Usuarios__A9D10534F50A25DF")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Pettapp2.Models.Accesorio", b =>
                {
                    b.HasOne("Pettapp2.Models.Usuario", "Vendedor")
                        .WithMany("Accesorios")
                        .HasForeignKey("VendedorId")
                        .IsRequired()
                        .HasConstraintName("FK_Accesorio_Usuario");

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("Pettapp2.Models.Adopcione", b =>
                {
                    b.HasOne("Pettapp2.Models.Mascota", "Mascota")
                        .WithMany("Adopciones")
                        .HasForeignKey("MascotaId")
                        .IsRequired()
                        .HasConstraintName("FK_Adopcion_Mascota");

                    b.HasOne("Pettapp2.Models.Usuario", "Usuario")
                        .WithMany("Adopciones")
                        .HasForeignKey("UsuarioId")
                        .IsRequired()
                        .HasConstraintName("FK_Adopcion_Usuario");

                    b.Navigation("Mascota");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Pettapp2.Models.CarritoAccesorio", b =>
                {
                    b.HasOne("Pettapp2.Models.Accesorio", "Accesorio")
                        .WithMany("CarritoAccesorios")
                        .HasForeignKey("AccesorioId")
                        .IsRequired()
                        .HasConstraintName("FK_CarritoAccesorio_Accesorio");

                    b.HasOne("Pettapp2.Models.CarritoDeCompra", "Carrito")
                        .WithMany("CarritoAccesorios")
                        .HasForeignKey("CarritoId")
                        .IsRequired()
                        .HasConstraintName("FK_CarritoAccesorio_Carrito");

                    b.Navigation("Accesorio");

                    b.Navigation("Carrito");
                });

            modelBuilder.Entity("Pettapp2.Models.CarritoDeCompra", b =>
                {
                    b.HasOne("Pettapp2.Models.Usuario", "Usuario")
                        .WithMany("CarritoDeCompras")
                        .HasForeignKey("UsuarioId")
                        .IsRequired()
                        .HasConstraintName("FK_Carrito_Usuario");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Pettapp2.Models.Donacione", b =>
                {
                    b.HasOne("Pettapp2.Models.Refugio", "Refugio")
                        .WithMany("Donaciones")
                        .HasForeignKey("RefugioId")
                        .IsRequired()
                        .HasConstraintName("FK_Donacion_Refugio");

                    b.HasOne("Pettapp2.Models.Usuario", "Usuario")
                        .WithMany("Donaciones")
                        .HasForeignKey("UsuarioId")
                        .IsRequired()
                        .HasConstraintName("FK_Donacion_Usuario");

                    b.Navigation("Refugio");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Pettapp2.Models.Mascota", b =>
                {
                    b.HasOne("Pettapp2.Models.Refugio", "Refugio")
                        .WithMany("Mascota")
                        .HasForeignKey("RefugioId")
                        .IsRequired()
                        .HasConstraintName("FK_Mascota_Refugio");

                    b.Navigation("Refugio");
                });

            modelBuilder.Entity("Pettapp2.Models.Refugio", b =>
                {
                    b.HasOne("Pettapp2.Models.Usuario", "Usuario")
                        .WithMany("Refugios")
                        .HasForeignKey("UsuarioId")
                        .IsRequired()
                        .HasConstraintName("FK_Refugio_Usuario");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Pettapp2.Models.Usuario", b =>
                {
                    b.HasOne("Pettapp2.Models.Role", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId")
                        .IsRequired()
                        .HasConstraintName("FK_Usuario_Rol");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Pettapp2.Models.Accesorio", b =>
                {
                    b.Navigation("CarritoAccesorios");
                });

            modelBuilder.Entity("Pettapp2.Models.CarritoDeCompra", b =>
                {
                    b.Navigation("CarritoAccesorios");
                });

            modelBuilder.Entity("Pettapp2.Models.Mascota", b =>
                {
                    b.Navigation("Adopciones");
                });

            modelBuilder.Entity("Pettapp2.Models.Refugio", b =>
                {
                    b.Navigation("Donaciones");

                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("Pettapp2.Models.Role", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Pettapp2.Models.Usuario", b =>
                {
                    b.Navigation("Accesorios");

                    b.Navigation("Adopciones");

                    b.Navigation("CarritoDeCompras");

                    b.Navigation("Donaciones");

                    b.Navigation("Refugios");
                });
#pragma warning restore 612, 618
        }
    }
}
