using HikiCoffee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiCoffee.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(200);

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Dob).IsRequired();

            builder.Property(x => x.UrlImageUser).HasMaxLength(1000).IsUnicode(false);

            builder.Property(x => x.MoreInfo).HasMaxLength(1000);

            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.HasOne(x => x.Gender).WithMany(x => x.AppUsers).HasForeignKey(x => x.GenderId);

            builder.Property(x => x.RefreshToken).IsRequired(false).HasMaxLength(1000).IsUnicode(false);

            builder.Property(x => x.TokenCreated).IsRequired(false);

            builder.Property(x => x.TokenExpires).IsRequired(false);
        }
    }
}
