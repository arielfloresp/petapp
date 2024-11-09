using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pettapp2.Models;

public partial class PetappContext : DbContext
{
    public PetappContext()
    {
    }

    public PetappContext(DbContextOptions<PetappContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accesorio> Accesorios { get; set; }
    public virtual DbSet<Adopcione> Adopciones { get; set; }
    public virtual DbSet<CarritoAccesorio> CarritoAccesorios { get; set; }
    public virtual DbSet<CarritoDeCompra> CarritoDeCompras { get; set; }
    public virtual DbSet<Donacione> Donaciones { get; set; }
    public virtual DbSet<Mascota> Mascotas { get; set; }
    public virtual DbSet<Refugio> Refugios { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<ConfirmacionCompra> ConfirmacionesCompra { get; set; } // Nueva tabla de confirmaciones de compra
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SERG\\SQLEXPRESS;Database=Petapp;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accesorio>(entity =>
        {
            entity.HasKey(e => e.AccesorioId).HasName("PK__Accesori__4BCD4EA9B26B191C");

            entity.Property(e => e.AccesorioId).HasColumnName("AccesorioID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.VendedorId).HasColumnName("VendedorID");

            entity.HasOne(d => d.Vendedor).WithMany(p => p.Accesorios)
                .HasForeignKey(d => d.VendedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Accesorio_Usuario");
        });

        modelBuilder.Entity<Adopcione>(entity =>
        {
            entity.HasKey(e => e.AdopcionId).HasName("PK__Adopcion__AAEE3F678C3CC459");

            entity.HasIndex(e => new { e.UsuarioId, e.MascotaId }, "UC_Usuario_Mascota").IsUnique();

            entity.Property(e => e.AdopcionId).HasColumnName("AdopcionID");
            entity.Property(e => e.FechaAdopcion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MascotaId).HasColumnName("MascotaID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Mascota).WithMany(p => p.Adopciones)
                .HasForeignKey(d => d.MascotaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Adopcion_Mascota");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Adopciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Adopcion_Usuario");
        });

        modelBuilder.Entity<CarritoAccesorio>(entity =>
        {
            entity.HasKey(e => e.CarritoAccesorioId).HasName("PK__CarritoA__ABF0DCC17C1BC6E0");

            entity.Property(e => e.CarritoAccesorioId).HasColumnName("CarritoAccesorioID");
            entity.Property(e => e.AccesorioId).HasColumnName("AccesorioID");
            entity.Property(e => e.CarritoId).HasColumnName("CarritoID");

            entity.HasOne(d => d.Accesorio).WithMany(p => p.CarritoAccesorios)
                .HasForeignKey(d => d.AccesorioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarritoAccesorio_Accesorio");

            entity.HasOne(d => d.Carrito).WithMany(p => p.CarritoAccesorios)
                .HasForeignKey(d => d.CarritoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarritoAccesorio_Carrito");
        });

        modelBuilder.Entity<CarritoDeCompra>(entity =>
        {
            entity.HasKey(e => e.CarritoId).HasName("PK__CarritoD__778D580BB115B576");

            entity.Property(e => e.CarritoId).HasColumnName("CarritoID");
            entity.Property(e => e.Total)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.CarritoDeCompras)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carrito_Usuario");
        });

        modelBuilder.Entity<Donacione>(entity =>
        {
            entity.HasKey(e => e.DonacionId).HasName("PK__Donacion__9F5DEEE7368907D4");

            entity.Property(e => e.DonacionId).HasColumnName("DonacionID");
            entity.Property(e => e.FechaDonacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RefugioId).HasColumnName("RefugioID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Refugio).WithMany(p => p.Donaciones)
                .HasForeignKey(d => d.RefugioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Donacion_Refugio");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Donaciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Donacion_Usuario");
        });

        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.MascotaId).HasName("PK__Mascotas__8DBC411CC52B78B1");

            entity.Property(e => e.MascotaId).HasColumnName("MascotaID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.EstadoAdopcion)
                .HasMaxLength(20)
                .HasDefaultValue("Disponible");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Raza).HasMaxLength(50);
            entity.Property(e => e.RefugioId).HasColumnName("RefugioID");
            entity.Property(e => e.Sexo).HasMaxLength(10);

            entity.HasOne(d => d.Refugio).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.RefugioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mascota_Refugio");
        });

        modelBuilder.Entity<Refugio>(entity =>
        {
            entity.HasKey(e => e.RefugioId).HasName("PK__Refugios__AD4F9C4244E2CBE1");

            entity.Property(e => e.RefugioId).HasColumnName("RefugioID");
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Refugios)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Refugio_Usuario");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302D1E14BB533");

            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE798DED20E77");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D10534F50A25DF").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.RolId).HasColumnName("RolID");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Rol");
        });

        modelBuilder.Entity<ConfirmacionCompra>(entity =>
        {
            entity.HasKey(e => e.ConfirmacionCompraId);

            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.BancoDestino).HasMaxLength(100);
            entity.Property(e => e.NumeroTransaccion).HasMaxLength(50);
            entity.Property(e => e.MontoAbonado).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ComprobantePath).HasMaxLength(255);
            entity.Property(e => e.Fecha).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
