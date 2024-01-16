using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using assignment2.Models;

namespace assignment2.Data;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext()
    {
    }

    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=NORTHWIND");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CustomerId).IsFixedLength();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).ValueGeneratedNever();
            entity.Property(e => e.CustomerId).IsFixedLength();
            entity.Property(e => e.Freight).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders).HasConstraintName("FK_orders_customers");

            entity.HasOne(d => d.ShipViaNavigation).WithMany(p => p.Orders).HasConstraintName("FK_orders_shippers");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ReorderLevel).HasDefaultValueSql("((0))");
            entity.Property(e => e.UnitPrice).HasDefaultValueSql("((0))");
            entity.Property(e => e.UnitsInStock).HasDefaultValueSql("((0))");
            entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK_products_categories");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products).HasConstraintName("FK_products_suppliers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
