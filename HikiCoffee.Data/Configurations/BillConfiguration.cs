using HikiCoffee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiCoffee.Data.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bills");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.DateCheckIn).IsRequired(true);

            builder.Property(x => x.DateCheckOut).IsRequired(false);

            builder.Property(x => x.TotalPayPrice).HasDefaultValue(0).IsRequired().IsRequired(true);

            builder.HasOne(x => x.CoffeeTable).WithMany(x => x.Bills).HasForeignKey(x => x.CoffeeTabelId);

            builder.HasOne(x => x.AppUser).WithMany(x => x.Bills).HasForeignKey(x => x.UserCustomerId);

            builder.HasOne(x => x.AppUser).WithMany(x => x.Bills).HasForeignKey(x => x.UserPaymentId);

            builder.HasOne(x => x.Status).WithMany(x => x.Bills).HasForeignKey(x => x.StatusId);

        }
    }
}
