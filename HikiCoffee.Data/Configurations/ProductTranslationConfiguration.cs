using HikiCoffee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiCoffee.Data.Configurations
{
    public class ProductTranslationConfiguration : IEntityTypeConfiguration<ProductTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductTranslation> builder)
        {
            builder.ToTable("ProductTranslations");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.NameProduct).IsRequired(true).HasMaxLength(200);

            builder.Property(x => x.Details).HasMaxLength(500).IsRequired(false);

            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(1000);

            builder.Property(x => x.SeoAlias).IsRequired(true).HasMaxLength(200);

            builder.Property(x => x.SeoTitle).IsRequired(false).HasMaxLength(200);

            builder.Property(x => x.SeoDescription).IsRequired(false).HasMaxLength(500);

            builder.Property(x => x.LanguageId).IsUnicode(false).IsRequired().HasMaxLength(5);

            builder.HasOne(x => x.Language).WithMany(x => x.ProductTranslations).HasForeignKey(x => x.LanguageId);

            builder.HasOne(x => x.Product).WithMany(x => x.ProductTranslations).HasForeignKey(x => x.ProductId);

        }
    }
}
