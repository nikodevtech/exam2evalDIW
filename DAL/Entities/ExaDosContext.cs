using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities;

public partial class ExaDosContext : DbContext
{
    public ExaDosContext()
    {
    }

    public ExaDosContext(DbContextOptions<ExaDosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<RelPrestamoVajilla> RelPrestamoVajillas { get; set; }

    public virtual DbSet<Vajilla> Vajillas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=PostgresConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).HasName("prestamos_pkey");

            entity.ToTable("prestamos", "esq_exa_dos");

            entity.Property(e => e.IdPrestamo).HasColumnName("id_prestamo");
            entity.Property(e => e.FechaPrestamo).HasColumnName("fecha_prestamo");
        });

        modelBuilder.Entity<RelPrestamoVajilla>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rel_prestamo_vajilla", "esq_exa_dos");

            entity.Property(e => e.PrestamoIdFk).HasColumnName("prestamo_id_fk");
            entity.Property(e => e.VajillaIdFk).HasColumnName("vajilla_id_fk");

            entity.HasOne(d => d.PrestamoIdFkNavigation).WithMany()
                .HasForeignKey(d => d.PrestamoIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk70j1my88m202j6ywfyqlmijd4");

            entity.HasOne(d => d.VajillaIdFkNavigation).WithMany()
                .HasForeignKey(d => d.VajillaIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk3u1qit5vb1tfhmqrcomp5iua3");
        });

        modelBuilder.Entity<Vajilla>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("vajillas_pkey");

            entity.ToTable("vajillas", "esq_exa_dos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Codigo)
                .HasMaxLength(255)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
