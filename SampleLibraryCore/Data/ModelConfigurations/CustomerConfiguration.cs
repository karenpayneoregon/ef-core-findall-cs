using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleLibraryCore.Models;

#nullable disable

namespace SampleLibraryCore.Data.ModelConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.HasKey(e => e.CustomerIdentifier)
                .HasName("PK_Customers_1");

            entity.Property(e => e.CustomerIdentifier).HasComment("Id");

            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasComment("Street");

            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasComment("City");

            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("Company");

            entity.Property(e => e.ContactId).HasComment("ContactId");

            entity.Property(e => e.ContactName)
                .HasMaxLength(30)
                .HasComment("Contact");

            entity.Property(e => e.ContactTypeIdentifier).HasComment("ContactTypeIdentifier");

            entity.Property(e => e.CountryIdentifier).HasComment("CountryIdentifier");

            entity.Property(e => e.Fax)
                .HasMaxLength(24)
                .HasComment("Fax");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Modified Date");

            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasComment("Phone");

            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasComment("Postal Code");

            entity.Property(e => e.Region)
                .HasMaxLength(15)
                .HasComment("Region");

            entity.HasOne(d => d.Contact)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK_Customers_Contacts");

            entity.HasOne(d => d.ContactTypeIdentifierNavigation)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.ContactTypeIdentifier)
                .HasConstraintName("FK_Customers_ContactType");

            entity.HasOne(d => d.CountryIdentifierNavigation)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.CountryIdentifier)
                .HasConstraintName("FK_Customers_Countries");
        }
    }
}
