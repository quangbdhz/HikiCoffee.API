using HikiCoffee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HikiCoffee.Data.Configurations
{
    public class AppointmentScheduleConfiguration : IEntityTypeConfiguration<AppointmentSchedule>
    {
        public void Configure(EntityTypeBuilder<AppointmentSchedule> builder)
        {
            builder.ToTable("AppointmentSchedules");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.ExpirationTime).IsRequired(true);

            builder.Property(x => x.AppointmentTime).IsRequired(true);

            builder.Property(x => x.MoreInfo).HasMaxLength(1000).IsRequired(false);

            builder.HasOne(x => x.AppUser).WithMany(x => x.AppointmentSchedules).HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.CoffeeTable).WithMany(x => x.AppointmentSchedules).HasForeignKey(x => x.CoffeeTableId);


        }
    }
}
