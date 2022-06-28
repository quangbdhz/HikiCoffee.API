using HikiCoffee.Data.Configurations;
using HikiCoffee.Data.Entities;
using HikiCoffee.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HikiCoffee.Data.EF
{
    public class HikiCoffeeDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public HikiCoffeeDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new BillConfiguration());
            modelBuilder.ApplyConfiguration(new BillInfoConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new CoffeeTableConfiguration()) ;
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new ImportProductConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new StatusTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new SuplierConfiguration());
            modelBuilder.ApplyConfiguration(new UnitConfiguration());
            modelBuilder.ApplyConfiguration(new UnitTranslationConfiguration());

            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            modelBuilder.Seed();


            //base.OnModelCreating(modelBuilder);

        }



        public DbSet<AppointmentSchedule> AppointmentSchedules { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<BillInfo> BillInfos { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }

        public DbSet<CoffeeTable> CoffeeTables { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<ImportProduct> ImportProducts { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<ProductInCategory> ProductInCategories { get; set; }

        public DbSet<ProductTranslation> ProductTranslations { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<StatusTranslation> StatusTranslations { get; set; }

        public DbSet<Suplier> Supliers { get; set; }

        public DbSet<Unit> Uses { get; set; }

        public DbSet<UnitTranslation> UnitTranslations { get; set; }
    }
}
