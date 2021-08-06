using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleLibraryCore.Models;

#nullable disable

namespace SampleLibraryCore.Data.ModelConfigurations
{
    public class LanguageCodeConfiguration : IEntityTypeConfiguration<LanguageCode>
    {
        public void Configure(EntityTypeBuilder<LanguageCode> entity)
        {
            entity.HasKey(e => e.LanguageId);

            entity.Property(e => e.ColumnDescription).HasColumnName("columnDescription");
        }
    }
}
