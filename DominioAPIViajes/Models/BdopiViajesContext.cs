using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DominioAPIViajes.Models;

public partial class BdopiViajesContext : DbContext
{
    public BdopiViajesContext()
    {
    }

    public BdopiViajesContext(DbContextOptions<BdopiViajesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<EstadoReserva> EstadoReservas { get; set; }

    public virtual DbSet<ModoPago> ModoPagos { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pais> Pais { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Terminal> Terminals { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TipoTerminal> TipoTerminals { get; set; }

    public virtual DbSet<TipoViaje> TipoViajes { get; set; }

    public virtual DbSet<Transportador> Transportadors { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-7APGCIF\\SQLEXPRESS;Initial Catalog=BDOpiViajes;User ID=sa;Password=sa;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pkCiudad");

            entity.ToTable("Ciudad");

            entity.HasIndex(e => new { e.IdPais, e.Nombre }, "ixCiudad").IsUnique();

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Pais).WithMany(p => p.Ciudades)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkCiudad_IdPais");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pkCliente");

            entity.ToTable("Cliente");

            entity.HasIndex(e => new { e.IdTipoDocumento, e.Documento }, "ixCliente").IsUnique();

            entity.HasIndex(e => e.Nombre, "ixClienteNombre");

            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Documento)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Movil)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Ciudad).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdCiudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkCliente_IdCiudad");


        });

        modelBuilder.Entity<EstadoReserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pkEstadoReserva");

            entity.ToTable("EstadoReserva");

            entity.HasIndex(e => e.Estado, "ixEstadoReserva").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ModoPago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pkModoPago");

            entity.ToTable("ModoPago");

            entity.HasIndex(e => e.Modo, "ixModoPago").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Modo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pkPago");

            entity.ToTable("Pago");

            entity.Property(e => e.Fecha).HasColumnType("datetime");


            entity.HasOne(d => d.Reserva).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkPago_IdReserva");
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pkPais");

            entity.HasIndex(e => e.Nombre, "ixPais").IsUnique();

            entity.Property(e => e.CodigoAlfa)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pkReserva");

            entity.ToTable("Reserva");

            entity.Property(e => e.Fecha).HasColumnType("datetime");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkReserva_IdCliente");


            entity.HasOne(d => d.Viaje).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdViaje)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkReserva_IdViaje");

        });

        modelBuilder.Entity<Terminal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pkTerminal");

            entity.ToTable("Terminal");

            entity.HasIndex(e => e.Nombre, "ixTerminal").IsUnique();

            entity.Property(e => e.CodigoIata)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("CodigoIATA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Ciudad).WithMany(p => p.Terminales)
                .HasForeignKey(d => d.IdCiudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkTerminal_IdCiudad");

        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pkTipoDocumento");

            entity.ToTable("TipoDocumento");

            entity.HasIndex(e => e.Tipo, "ixTipoDocumento").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Sigla)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoTerminal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pkTipoTerminal");

            entity.ToTable("TipoTerminal");

            entity.HasIndex(e => e.Tipo, "ixTipoTerminal").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoViaje>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pkTipoViaje");

            entity.ToTable("TipoViaje");

            entity.HasIndex(e => e.Tipo, "ixTipoViaje").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Tipo)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Transportador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pkTransportador");

            entity.ToTable("Transportador");

            entity.HasIndex(e => e.Nombre, "ixTransportador").IsUnique();

            entity.Property(e => e.Codigo)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Pais).WithMany(p => p.Transportadores)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkTransportador_IdPais");
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pkViaje");

            entity.ToTable("Viaje");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
