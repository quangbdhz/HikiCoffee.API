using HikiCoffee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HikiCoffee.Data.Configurations
{
    public class ImportProductConfiguration : IEntityTypeConfiguration<ImportProduct>
    {
        public void Configure(EntityTypeBuilder<ImportProduct> builder)
        {
            builder.ToTable("ImportProducts");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.DateImportProduct).IsRequired(true);

            builder.Property(x => x.Quantity).IsRequired(true);

            builder.HasOne(x => x.AppUser).WithMany(x => x.ImportProducts).HasForeignKey(x => x.UserIdImportProduct);

            builder.HasOne(x => x.Product).WithMany(x => x.ImportProducts).HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Suplier).WithMany(x => x.ImportProducts).HasForeignKey(x => x.SuplierId);

        }
    }
}
