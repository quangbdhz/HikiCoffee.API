using HikiCoffee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiCoffee.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.UrlImageCoverProduct).IsUnicode(false).HasMaxLength(1000).IsRequired(false);

            builder.Property(x => x.Price).IsRequired(true);

            builder.Property(x => x.OriginalPrice).IsRequired(true);

            builder.Property(x => x.Stock).IsRequired(true).HasDefaultValue(0).IsRequired(true);

            builder.Property(x => x.ViewCount).IsRequired(true).HasDefaultValue(0);

            builder.Property(x => x.DateCreated).IsRequired(true);

            builder.Property(x => x.IsFeatured).HasDefaultValue(false).IsRequired(false);

            builder.Property(x => x.IsActive).HasDefaultValue(true).IsRequired(true);

            builder.HasOne(x => x.Unit).WithMany(x => x.Products).HasForeignKey(x => x.UnitId).IsRequired(false);
        }
    }
}
