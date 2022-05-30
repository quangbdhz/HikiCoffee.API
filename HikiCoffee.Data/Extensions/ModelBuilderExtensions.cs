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
                new Status() { Id = 1, IsActive = true, DateCreated = DateTime.Now },
                new Status() { Id = 2, IsActive = true, DateCreated = DateTime.Now },
                new Status() { Id = 3, IsActive = true, DateCreated = DateTime.Now },
                new Status() { Id = 4, IsActive = true, DateCreated = DateTime.Now });

            modelBuilder.Entity<StatusTranslation>().HasData(
                new StatusTranslation() { Id = 1, StatusId = 1, LanguageId = 1, NameStatus = "Đã Thanh Toán" },
                new StatusTranslation() { Id = 2, StatusId = 1, LanguageId = 2, NameStatus = "Paid" },
                new StatusTranslation() { Id = 3, StatusId = 2, LanguageId = 1, NameStatus = "Chưa Thanh Toán" },
                new StatusTranslation() { Id = 4, StatusId = 2, LanguageId = 2, NameStatus = "Unpaid" },
                new StatusTranslation() { Id = 5, StatusId = 3, LanguageId = 1, NameStatus = "Bàn Còn Trống" },
                new StatusTranslation() { Id = 6, StatusId = 3, LanguageId = 2, NameStatus = "Tables Are Empty" },
                new StatusTranslation() { Id = 7, StatusId = 4, LanguageId = 1, NameStatus = "Bàn Đang Sử Dụng" },
                new StatusTranslation() { Id = 8, StatusId = 4, LanguageId = 2, NameStatus = "Table In Use" });

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
                new Category() { Id = 1, SortOrder = 1, IsShowOnHome = true, ParentId = null, IsActive = true },
                new Category() { Id = 2, SortOrder = 2, IsShowOnHome = true, ParentId = null, IsActive = true });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation() { Id = 1, CategoryId = 1, NameCategory = "Coffee", LanguageId = 2, SeoAlias = "/coffee-black-381831", SeoDescription = "Good", SeoTitle = "Product Coffee"},
                new CategoryTranslation() { Id = 2, CategoryId = 1, NameCategory = "Cà Phê", LanguageId = 1, SeoAlias = "/ca-phe-den-838442", SeoDescription = "Good Drink", SeoTitle = "Sản phầm cà phê" },
                new CategoryTranslation() { Id = 3, CategoryId = 2, NameCategory = "Tea", LanguageId = 2, SeoAlias = "/tea-342242", SeoDescription = "Good", SeoTitle = "Product Tea" },
                new CategoryTranslation() { Id = 4, CategoryId = 2, NameCategory = "Trà", LanguageId = 1, SeoAlias = "/tra-837113", SeoDescription = "Good Drink", SeoTitle = "Sản phầm trà" });

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

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, IsActive = true, DateCreated = DateTime.Now, IsFeatured = true, ViewCount = 0, Stock = 5, OriginalPrice = 100000, Price = 90000, UrlImageCoverProduct = "https://i.pinimg.com/originals/ea/3f/37/ea3f37ad3242d1796f7136741dcebfbd.jpg" },
                new Product() { Id = 2, IsActive = true, DateCreated = DateTime.Now, IsFeatured = false, ViewCount = 0, Stock = 15, OriginalPrice = 55000, Price = 47000, UrlImageCoverProduct = "https://coffeebean.com.vn/wp-content/uploads/2019/09/Matcha-green-tea-Affogato-1.png" },
                new Product() { Id = 3, IsActive = true, DateCreated = DateTime.Now, IsFeatured = true, ViewCount = 0, Stock = 9, OriginalPrice = 84000, Price = 72000, UrlImageCoverProduct = "https://www.coffeesphere.com/wp-content/uploads/2020/07/what-is-americano.jpeg" });

            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation() { Id = 1, ProductId = 1, LanguageId = 1, NameProduct = "Cà phê đen", Description = "Cà phê đen thơm ngon từng vị", Details = "<h2><span style='font-size: 95%;'>Cà phê đen đóng chai nguyên chất tại Hà Nội</span></h2><p>Mua<strong> cà phê đen đóng chai </strong>online vào thời điểm này đang là lựa chọn số một cho những người yêu thích cà phê. Tình hình chống dịch của Hà Nội đang rất căng thẳng. Hàng quán thì đóng cửa, đi lại bị hạn chế, và không được tụ tập đông người. Nên cách tốt nhất vẫn là ngồi ở nhà hay ở chỗ làm và mua online một ly cà phê để thưởng thức</p>", SeoAlias = "/ca-phe-den-193412", SeoDescription = "Cafe đen bạn của mọi nhà", SeoTitle = "Cafe đen đậm vị thơm ngon" },
                new ProductTranslation() { Id = 2, ProductId = 1, LanguageId = 2, NameProduct = "Black Coffee", Description = "Black Coffee Is The Best", Details = "Black Coffee", SeoAlias = "/black-coffee-918413", SeoTitle = "Black Coffee", SeoDescription = "Coffee" },
                new ProductTranslation() { Id = 3, ProductId = 2, LanguageId = 1, NameProduct = "Trà xanh Matcha", Description = "Trà xanh siêu ngon", Details = "Trà xanh Matcha siêu <strong>thơm</strong> ngon", SeoAlias = "/tra-xanh-matcha-741413", SeoTitle = "Trà xanh Matcha", SeoDescription = "Trà xanh Matcha" },
                new ProductTranslation() { Id = 4, ProductId = 2, LanguageId = 2, NameProduct = "Matcha Green Tea", Description = "Matcha Green Tea", Details = "Matcha Green Tea Is The Best", SeoAlias = "/matcha-green-tea-414131", SeoTitle = "Matcha Green Tea", SeoDescription = "Matcha Green Tea" },
                new ProductTranslation() { Id = 5, ProductId = 3, LanguageId = 1, NameProduct = "Cà phê Americano", Description = "Cà phê Americano", Details = "Cà phê Americano Ngon", SeoAlias = "/ca-phe-americano-371471", SeoTitle = "Cà phê Americano", SeoDescription = "Cà phê Americano" },
                new ProductTranslation() { Id = 6, ProductId = 3, LanguageId = 2, NameProduct = "Americano", Description = "Americano", Details = "Americano", SeoAlias = "/americano-347272", SeoTitle = "Americano", SeoDescription = "Americano" });

            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 },
                new ProductInCategory() { ProductId = 2, CategoryId = 2 },
                new ProductInCategory() { ProductId = 3, CategoryId = 1 });

            modelBuilder.Entity<ProductImage>().HasData(
                new ProductImage() { Id = 1, ProductId = 1, UrlImageProduct = "https://icdn.dantri.com.vn/thumb_w/640/2021/03/04/vi-ca-phe-den-het-nhu-vi-cuoc-songdocx-1614866315610.png", Caption = "image 1", DateCreated = DateTime.Now },
                new ProductImage() { Id = 2, ProductId = 1, UrlImageProduct = "https://artcoffee.vn/wp-content/uploads/2020/09/8-loi-ich-to-lon-cua-viec-uong-ca-phe-den-nguyen-chat-khong-duong.jpg", Caption = "image 2", DateCreated = DateTime.Now },
                new ProductImage() { Id = 3, ProductId = 1, UrlImageProduct = "https://doisongbiz.com/wp-content/uploads/2017/04/bi-quyet-giam-can-nhanh-chong-bang-cafe-den.jpg", Caption = "image 3", DateCreated = DateTime.Now },
                new ProductImage() { Id = 4, ProductId = 2, UrlImageProduct = "https://images.japancentre.com/recipes/pics/16/main/matcha-latte.jpg?1469572822", Caption = "image 1", DateCreated = DateTime.Now },
                new ProductImage() { Id = 5, ProductId = 2, UrlImageProduct = "https://gimmedelicious.com/wp-content/uploads/2018/03/Iced-Matcha-Latte2.jpg", Caption = "image 2", DateCreated = DateTime.Now },
                new ProductImage() { Id = 6, ProductId = 3, UrlImageProduct = "https://cdn.tgdd.vn/2021/11/CookDish/americano-la-gi-nguon-goc-cach-pha-americano-don-gian-va-avt-1200x676.jpg", Caption = "image 1", DateCreated = DateTime.Now });




        }
    }
}
