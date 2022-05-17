using HikiCoffee.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HikiCoffee.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = 1, Code = "vi-VN", NameLanguage = "Tiếng Việt", IsDefault = true },
                new Language() { Id = 2, Code = "en-US", NameLanguage = "English", IsDefault = false });

            modelBuilder.Entity<Status>().HasData(
                new Status() { Id = 1, NameStatus = "Đã Thanh Toán", IsActive = true },
                new Status() { Id = 2, NameStatus = "Chưa Thanh Toán", IsActive = true },
                new Status() { Id = 3, NameStatus = "Bàn Còn Trống", IsActive = true },
                new Status() { Id = 4, NameStatus = "Bàn Đang Sử Dụng", IsActive = true });

            var adminRoleId = new Guid("E1DB1200-1BB6-4156-9DA3-135E91D94ABA");
            var staffRoleId = new Guid("C489F858-AABD-4264-96C1-5CDCA251D871");
            var customerRoleId = new Guid("2F0C7B75-8934-4101-BEF2-C850E42D21DE");

            modelBuilder.Entity<AppRole>().HasData(
                new AppRole() { Id = adminRoleId, Name = "admin", NormalizedName = "admin", Description = "Administrator role" },
                new AppRole() { Id = staffRoleId, Name = "staff", NormalizedName = "staff", Description = "Staff role" },
                new AppRole() { Id = customerRoleId, Name = "customer", NormalizedName = "customer", Description = "Customer role" });

            modelBuilder.Entity<Gender>().HasData(
                new Gender() { Id = 1, NameGender = "Male", IsActive = true },
                new Gender() { Id = 2, NameGender = "Female", IsActive = true });

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, SortOrder = 1, IsShowOnHome = true, ParentId = null, IsActive = true });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation() { Id = 1, CategoryId = 1, NameCategory = "Coffee", LanguageId = 2, SeoAlias = "coffee-black", SeoDescription = "Good", SeoTitle = "Product Coffee"},
                new CategoryTranslation() { Id = 2, CategoryId = 1, NameCategory = "Cà Phê", LanguageId = 1, SeoAlias = "ca-phe-den", SeoDescription = "Good Drink", SeoTitle = "Sản phầm cà phê" });

            modelBuilder.Entity<Unit>().HasData(
                new Unit() { Id = 1, IsActive = true });

            modelBuilder.Entity<UnitTranslation>().HasData(
                new UnitTranslation() { Id = 1, UnitId = 1, NameUnit = "Cỡ X", MoreInfo = "", LanguageId = 1 },
                new UnitTranslation() { Id = 2, UnitId = 1, NameUnit = "Size X", MoreInfo = "Size X", LanguageId = 2 });

            var adminId = new Guid("0B64F6F0-9F60-45C9-9E7B-F68CCC3FC57F");

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser() {
                    Id = adminId,
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    Email = "tranquangbhdz@gmail.com",
                    NormalizedEmail = "tranquangbhdz@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                    SecurityStamp = string.Empty,
                    FirstName = "Tran",
                    LastName = "Quang",
                    Dob = new DateTime(2001, 10, 08),
                    UrlImageUser = "https://64.media.tumblr.com/f3685609f6f9e0f15b70b740380fe0db/85dff69cc547be63-1d/s640x960/a0fa84e4ec96b338ec45f925baccc9619131013c.jpg",
                    MoreInfo = "Chùm",
                    IsActive = true,
                    GenderId = 1
                });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = adminRoleId,
                UserId = adminId
            });
        }
    }
}
