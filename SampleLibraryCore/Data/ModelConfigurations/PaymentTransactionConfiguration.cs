using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleLibraryCore.Models;

#nullable disable

namespace SampleLibraryCore.Data.ModelConfigurations
{
    public class PaymentTransactionConfiguration : IEntityTypeConfiguration<PaymentTransaction>
    {
        public void Configure(EntityTypeBuilder<PaymentTransaction> entity)
        {
            entity.HasKey(e => e.TransactionIdentifier);

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.Property(e => e.PaymentDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.PaymentTypeIdentifierNavigation)
                .WithMany(p => p.PaymentTransactions)
                .HasForeignKey(d => d.PaymentTypeIdentifier)
                .HasConstraintName("FK_PaymentTransactions_PaymentTypes");
        }
    }
}
