using HikiCoffee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiCoffee.Data.Configurations
{
    public class CoffeeTableConfiguration : IEntityTypeConfiguration<CoffeeTable>
    {
        public void Configure(EntityTypeBuilder<CoffeeTable> builder)
        {
            builder.ToTable("CoffeeTables");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.NameCoffeeTable).HasMaxLength(100).IsRequired(true);

            builder.Property(x => x.AppointmentTime).IsRequired(false);

            builder.Property(x => x.ExpirationTime).IsRequired(false);

            builder.Property(x => x.IsActive).HasDefaultValue(true).IsRequired(true);
        }
    }
}
