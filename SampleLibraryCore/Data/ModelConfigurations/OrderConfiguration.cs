﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleLibraryCore.Models;

#nullable disable

namespace SampleLibraryCore.Data.ModelConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            entity.Property(e => e.Freight).HasColumnType("money");

            entity.Property(e => e.OrderDate).HasColumnType("datetime");

            entity.Property(e => e.RequiredDate).HasColumnType("datetime");

            entity.Property(e => e.ShipAddress).HasMaxLength(60);

            entity.Property(e => e.ShipCity).HasMaxLength(15);

            entity.Property(e => e.ShipCountry).HasMaxLength(15);

            entity.Property(e => e.ShipPostalCode).HasMaxLength(10);

            entity.Property(e => e.ShipRegion).HasMaxLength(15);

            entity.Property(e => e.ShippedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CustomerIdentifierNavigation)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerIdentifier)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Orders_Customers2");

            entity.HasOne(d => d.Employee)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Orders_Employees");

            entity.HasOne(d => d.ShipViaNavigation)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipVia)
                .HasConstraintName("FK_Orders_Shippers");
        }
    }
}
