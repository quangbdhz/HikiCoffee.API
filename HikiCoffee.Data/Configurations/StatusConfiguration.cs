using HikiCoffee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiCoffee.Data.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Statuses");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.NameStatus).HasMaxLength(200).IsRequired(true);

            builder.Property(x => x.IsActive).HasDefaultValue(true).IsRequired(true);

        }
    }
}
