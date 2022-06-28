using HikiCoffee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiCoffee.Data.Configurations
{
    public class SuplierConfiguration : IEntityTypeConfiguration<Suplier>
    {
        public void Configure(EntityTypeBuilder<Suplier> builder)
        {
            builder.ToTable("Supliers");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.NameSuplier).IsRequired(true).HasMaxLength(500);

            builder.Property(x => x.Address).HasMaxLength(500).IsRequired(true);

            builder.Property(x => x.Email).HasMaxLength(200).IsRequired(true).IsUnicode(false);

            builder.Property(x => x.Phone).HasMaxLength(20).IsRequired(false);

            builder.Property(x => x.ContractDate).IsRequired(true);

            builder.Property(x => x.MoreInfo).HasMaxLength(1000).IsRequired(false);

            builder.Property(x => x.IsActive).IsRequired(true).HasDefaultValue(true);


        }
    }
}
