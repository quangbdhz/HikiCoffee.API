using HikiCoffee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiCoffee.Data.Configurations
{
    public class StatusTranslationConfiguration : IEntityTypeConfiguration<StatusTranslation>
    {
        public void Configure(EntityTypeBuilder<StatusTranslation> builder)
        {
            builder.ToTable("StatusTranslations");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.NameStatus).IsRequired(true).HasMaxLength(200);

            builder.HasOne(x => x.Status).WithMany(x => x.StatusTranslations).HasForeignKey(x => x.StatusId);

            builder.HasOne(x => x.Language).WithMany(x => x.StatusTranslations).HasForeignKey(x => x.LanguageId);
        }
    }
}
