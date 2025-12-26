using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KyrsAPI.Models;

public partial class AutoServiceContext : DbContext
{
    public AutoServiceContext()
    {
        Database.EnsureCreated();
    }

    public AutoServiceContext(DbContextOptions<AutoServiceContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<TechnicalDatum> TechnicalData { get; set; }
    public virtual DbSet<Vehicle> Vehicles { get; set; }
    public virtual DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=TeacherPC;Initial Catalog=AutoServiceContext;User ID=user8;Password=user8;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Admin");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(true);
            entity.Property(e => e.Password)
                .HasMaxLength(2000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Clients__E67E1A04B257D298");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED1DD7D61E");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Manufacturer).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PartNumber).HasMaxLength(50);
            entity.Property(e => e.StockQuantity).HasDefaultValue(0);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<TechnicalDatum>(entity =>
        {
            entity.HasKey(e => e.TechnicalDataId).HasName("PK__Technica__4683B179241B1740");

            entity.Property(e => e.TechnicalDataId).HasColumnName("TechnicalDataID");
            entity.Property(e => e.LaborHours).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.Recommendations).HasMaxLength(500);
            entity.Property(e => e.ServiceDate).HasColumnType("datetime");
            entity.Property(e => e.ServiceType).HasMaxLength(50);
            entity.Property(e => e.TotalCost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.VehicleId).HasColumnName("VehicleID");
            entity.Property(e => e.WorkDescription).HasMaxLength(1000);

            entity.HasOne(d => d.Vehicle).WithMany(p => p.TechnicalData)
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("FK_TechnicalData_Vehicles");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("PK__Vehicles__476B54B2C94EBECE");

            entity.Property(e => e.VehicleId).HasColumnName("VehicleID");
            entity.Property(e => e.Brand).HasMaxLength(50);
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Color).HasMaxLength(30);
            entity.Property(e => e.EngineCapacity).HasColumnType("decimal(3, 1)");
            entity.Property(e => e.EngineType).HasMaxLength(30);
            entity.Property(e => e.LicensePlate).HasMaxLength(15);
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Vin)
                .HasMaxLength(17)
                .HasColumnName("VIN");

            entity.HasOne(d => d.Client).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_Vehicles_Clients");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
