using HikiCoffee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiCoffee.Data.Configurations
{
    public class UnitTranslationConfiguration : IEntityTypeConfiguration<UnitTranslation>
    {
        public void Configure(EntityTypeBuilder<UnitTranslation> builder)
        {
            builder.ToTable("UnitTranslations");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.NameUnit).HasMaxLength(200).IsRequired(true);

            builder.Property(x => x.MoreInfo).HasMaxLength(1000).IsRequired(false);

            builder.Property(x => x.LanguageId).IsUnicode(false).IsRequired(true).HasMaxLength(5);

            builder.HasOne(x => x.Unit).WithMany(x => x.UnitTranslations).HasForeignKey(x => x.UnitId);

            builder.HasOne(x => x.Language).WithMany(x => x.UnitTranslations).HasForeignKey(x => x.LanguageId);
        }
    }
}
