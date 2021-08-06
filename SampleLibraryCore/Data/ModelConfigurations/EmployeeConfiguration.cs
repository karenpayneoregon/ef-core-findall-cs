﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleLibraryCore.Models;

#nullable disable

namespace SampleLibraryCore.Data.ModelConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("EmployeeID");

            entity.Property(e => e.Address).HasMaxLength(60);

            entity.Property(e => e.BirthDate).HasColumnType("datetime");

            entity.Property(e => e.City).HasMaxLength(15);

            entity.Property(e => e.Country).HasMaxLength(15);

            entity.Property(e => e.Extension).HasMaxLength(4);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(10);

            entity.Property(e => e.HireDate).HasColumnType("datetime");

            entity.Property(e => e.HomePhone).HasMaxLength(24);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(e => e.PostalCode).HasMaxLength(10);

            entity.Property(e => e.Region).HasMaxLength(15);

            entity.Property(e => e.Title).HasMaxLength(30);

            entity.Property(e => e.TitleOfCourtesy).HasMaxLength(25);
        }
    }
}
