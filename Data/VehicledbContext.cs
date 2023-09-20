using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Mono.Models;

namespace Mono.Data;

public partial class VehicledbContext : DbContext
{
    public VehicledbContext()
    {
    }

    public VehicledbContext(DbContextOptions<VehicledbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<VehicleMake> VehicleMakes { get; set; }

    public virtual DbSet<VehicleModel> VehicleModels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLExpress; Initial catalog=Vehicledb; trusted_connection=yes; Encrypt=False"); 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VehicleMake>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table__3214EC075C468083");

            entity.ToTable("VehicleMake");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Abrv)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<VehicleModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VehicleM__3214EC071FDF9782");

            entity.ToTable("VehicleModel ");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Abrv)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);

            entity.HasOne(d => d.Make).WithMany(p => p.VehicleModels)
                .HasForeignKey(d => d.MakeId)
                .HasConstraintName("FK__VehicleMo__MakeI__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
