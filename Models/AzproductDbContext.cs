using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace azproductapi.Models;

public partial class AzproductDbContext : DbContext
{
    public AzproductDbContext()
    {
    }

    public AzproductDbContext(DbContextOptions<AzproductDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-FFFN5GG;Database=AZProductDB;TrustServerCertificate=true; Integrated security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.ProductTypeId, "IX_Products_ProductTypeId");

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products).HasForeignKey(d => d.ProductTypeId);
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.ToTable("ProductType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
