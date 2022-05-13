using HikiCoffee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiCoffee.Data.Configurations
{
    public class BillInfoConfiguration : IEntityTypeConfiguration<BillInfo>
    {
        public void Configure(EntityTypeBuilder<BillInfo> builder)
        {
            builder.ToTable("BillInfos");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Quantity).IsRequired();

            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.Amount).IsRequired();

            builder.HasOne(x => x.Product).WithMany(x => x.BillInfos).HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Bill).WithMany(x => x.BillInfos).HasForeignKey(x => x.BillId);


        }
    }
}
