using HikiCoffee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiCoffee.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.UrlImageCoverCategory).IsUnicode(false).HasMaxLength(500).IsRequired(true);

            builder.Property(x => x.IsShowOnHome).HasDefaultValue(true).IsRequired(false);

            builder.Property(x => x.ParentId).IsRequired(false);

            builder.Property(x => x.IsActive).HasDefaultValue(true).IsRequired(true);
        }
    }
}
