using HikiCoffee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiCoffee.Data.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Code).IsRequired(true).IsUnicode(false).HasMaxLength(5);

            builder.Property(x => x.NameLanguage).HasMaxLength(50).IsRequired(true);

            builder.Property(x => x.IsDefault).HasDefaultValue(false).IsRequired(true);
        }
    }
}
