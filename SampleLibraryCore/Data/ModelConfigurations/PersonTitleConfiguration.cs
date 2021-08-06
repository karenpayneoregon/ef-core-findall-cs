using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleLibraryCore.Models;

#nullable disable

namespace SampleLibraryCore.Data.ModelConfigurations
{
    public class PersonTitleConfiguration : IEntityTypeConfiguration<PersonTitle>
    {
        public void Configure(EntityTypeBuilder<PersonTitle> entity)
        {
            entity.ToTable("PersonTitle");
        }
    }
}
