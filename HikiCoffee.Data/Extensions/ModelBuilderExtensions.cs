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
                new Status() { Id = 4, IsActive = true, DateCreated = DateTime.Now },
                new Status() { Id = 5, IsActive = true, DateCreated = DateTime.Now });

            modelBuilder.Entity<StatusTranslation>().HasData(
                new StatusTranslation() { Id = 1, StatusId = 1, LanguageId = 1, NameStatus = "Đã Thanh Toán" },
                new StatusTranslation() { Id = 2, StatusId = 1, LanguageId = 2, NameStatus = "Paid" },
                new StatusTranslation() { Id = 3, StatusId = 2, LanguageId = 1, NameStatus = "Chưa Thanh Toán" },
                new StatusTranslation() { Id = 4, StatusId = 2, LanguageId = 2, NameStatus = "Unpaid" },
                new StatusTranslation() { Id = 5, StatusId = 3, LanguageId = 1, NameStatus = "Bàn Còn Trống" },
                new StatusTranslation() { Id = 6, StatusId = 3, LanguageId = 2, NameStatus = "Tables Are Empty" },
                new StatusTranslation() { Id = 7, StatusId = 4, LanguageId = 1, NameStatus = "Bàn Đang Sử Dụng" },
                new StatusTranslation() { Id = 8, StatusId = 4, LanguageId = 2, NameStatus = "Table In Use" },
                new StatusTranslation() { Id = 9, StatusId = 5, LanguageId = 1, NameStatus = "Hóa Đơn Đã Được Gộp" },
                new StatusTranslation() { Id = 10, StatusId = 5, LanguageId = 2, NameStatus = "Invoices Consolidated" });

            var adminRoleId = new Guid("E1DB1200-1BB6-4156-9DA3-135E91D94ABA");
            var staffRoleId = new Guid("C489F858-AABD-4264-96C1-5CDCA251D871");
            var customerRoleId = new Guid("2F0C7B75-8934-4101-BEF2-C850E42D21DE");

            modelBuilder.Entity<AppRole>().HasData(
                new AppRole() { Id = adminRoleId, Name = "admin", NormalizedName = "admin", Description = "Administrator role" },
                new AppRole() { Id = staffRoleId, Name = "staff", NormalizedName = "staff", Description = "Staff role" },
                new AppRole() { Id = customerRoleId, Name = "customer", NormalizedName = "customer", Description = "Customer role" });

            modelBuilder.Entity<Gender>().HasData(
                new Gender() { Id = 1, NameGender = "Male", IsActive = true },
                new Gender() { Id = 2, NameGender = "Female", IsActive = true },
                new Gender() { Id = 3, NameGender = "Custom", IsActive = true });

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, SortOrder = 1, UrlImageCoverCategory = "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1655137566/HikiCoffee/Image_Category/Coffee_adqju2.png", IsShowOnHome = true, ParentId = null, IsActive = true },
                new Category() { Id = 2, SortOrder = 1, UrlImageCoverCategory = "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1655137567/HikiCoffee/Image_Category/Tea_ri0xmh.png", IsShowOnHome = true, ParentId = null, IsActive = true },
                new Category() { Id = 3, SortOrder = 1, UrlImageCoverCategory = "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1655137566/HikiCoffee/Image_Category/Capuchino_nofwkm.png", IsShowOnHome = true, ParentId = null, IsActive = true },
                new Category() { Id = 4, SortOrder = 1, UrlImageCoverCategory = "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1655137566/HikiCoffee/Image_Category/Beer_lxd9sc.png", IsShowOnHome = true, ParentId = null, IsActive = true },
                new Category() { Id = 5, SortOrder = 1, UrlImageCoverCategory = "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1655137566/HikiCoffee/Image_Category/Wine_ufhg6w.png", IsShowOnHome = true, ParentId = null, IsActive = true },
                new Category() { Id = 6, SortOrder = 1, UrlImageCoverCategory = "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1655392394/HikiCoffee/Image_Category/Juice_tn0vyi.png", IsShowOnHome = true, ParentId = null, IsActive = true },
                new Category() { Id = 7, SortOrder = 1, UrlImageCoverCategory = "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1655392394/HikiCoffee/Image_Category/Ice_Cream_ftsjti.png", IsShowOnHome = true, ParentId = null, IsActive = true },
                new Category() { Id = 8, SortOrder = 1, UrlImageCoverCategory = "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1655392394/HikiCoffee/Image_Category/Milktea_pkf5s5.png", IsShowOnHome = true, ParentId = null, IsActive = true },
                new Category() { Id = 9, SortOrder = 1, UrlImageCoverCategory = "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1655392394/HikiCoffee/Image_Category/Milk_siwgx5.png", IsShowOnHome = true, ParentId = null, IsActive = true });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation() { Id = 1, CategoryId = 1, NameCategory = "Coffee", LanguageId = 2, SeoAlias = "/coffee-black-381831", SeoDescription = "Good", SeoTitle = "Product Coffee"},
                new CategoryTranslation() { Id = 2, CategoryId = 1, NameCategory = "Cà Phê", LanguageId = 1, SeoAlias = "/ca-phe-den-838442", SeoDescription = "Good Drink", SeoTitle = "Sản phầm cà phê" },
                new CategoryTranslation() { Id = 3, CategoryId = 2, NameCategory = "Tea", LanguageId = 2, SeoAlias = "/tea-342242", SeoDescription = "Good", SeoTitle = "Product Tea" },
                new CategoryTranslation() { Id = 4, CategoryId = 2, NameCategory = "Trà", LanguageId = 1, SeoAlias = "/tra-837113", SeoDescription = "Good Drink", SeoTitle = "Sản phầm trà" },
                new CategoryTranslation() { Id = 5, CategoryId = 3, NameCategory = "Capuchino", LanguageId = 2, SeoAlias = "/capuchino-156342", SeoDescription = "Good", SeoTitle = "Product Capuchino" },
                new CategoryTranslation() { Id = 6, CategoryId = 3, NameCategory = "Capuchino", LanguageId = 1, SeoAlias = "/capuchino-537342", SeoDescription = "Good Drink", SeoTitle = "Sản phầm Capuchino" },
                new CategoryTranslation() { Id = 7, CategoryId = 4, NameCategory = "Beer", LanguageId = 2, SeoAlias = "/beer-942752", SeoDescription = "Good", SeoTitle = "Product Beer" },
                new CategoryTranslation() { Id = 8, CategoryId = 4, NameCategory = "Bia", LanguageId = 1, SeoAlias = "/bia-821964", SeoDescription = "Good Drink", SeoTitle = "Sản phầm bia" },
                new CategoryTranslation() { Id = 9, CategoryId = 5, NameCategory = "Wine", LanguageId = 2, SeoAlias = "/wine-105824", SeoDescription = "Good", SeoTitle = "Product Wine" },
                new CategoryTranslation() { Id = 10, CategoryId = 5, NameCategory = "Rược", LanguageId = 1, SeoAlias = "/ruoc-347134", SeoDescription = "Good Drink", SeoTitle = "Sản phầm rược" },
                new CategoryTranslation() { Id = 11, CategoryId = 6, NameCategory = "Juice", LanguageId = 2, SeoAlias = "/juice-942712", SeoDescription = "Good", SeoTitle = "Product Juice" },
                new CategoryTranslation() { Id = 12, CategoryId = 6, NameCategory = "Nước ép", LanguageId = 1, SeoAlias = "/nuoc-ep-413521", SeoDescription = "Good Drink", SeoTitle = "Sản phầm nước ép" },
                new CategoryTranslation() { Id = 13, CategoryId = 7, NameCategory = "Ice Cream", LanguageId = 2, SeoAlias = "/ice-cream-105824", SeoDescription = "Good", SeoTitle = "Product Ice Cream" },
                new CategoryTranslation() { Id = 14, CategoryId = 7, NameCategory = "Kem", LanguageId = 1, SeoAlias = "/kem-521564", SeoDescription = "Good Drink", SeoTitle = "Sản phầm kem" },
                new CategoryTranslation() { Id = 15, CategoryId = 8, NameCategory = "Milk tea", LanguageId = 2, SeoAlias = "/milk-tea-941712", SeoDescription = "Good", SeoTitle = "Product Milk Tea" },
                new CategoryTranslation() { Id = 16, CategoryId = 8, NameCategory = "Trà sữa", LanguageId = 1, SeoAlias = "/tra-sua-983343", SeoDescription = "Good Drink", SeoTitle = "Sản phầm trà sữa" },
                new CategoryTranslation() { Id = 17, CategoryId = 9, NameCategory = "Milk", LanguageId = 2, SeoAlias = "/milk-428413", SeoDescription = "Good", SeoTitle = "Product Milk" },
                new CategoryTranslation() { Id = 18, CategoryId = 9, NameCategory = "Sữa", LanguageId = 1, SeoAlias = "/sua-347134", SeoDescription = "Good Drink", SeoTitle = "Sản phầm sữa" });

            modelBuilder.Entity<Unit>().HasData(
                new Unit() { Id = 1, IsActive = true },
                new Unit() { Id = 2, IsActive = true });

            modelBuilder.Entity<UnitTranslation>().HasData(
                new UnitTranslation() { Id = 1, UnitId = 1, NameUnit = "Không có", MoreInfo = "", LanguageId = 1 },
                new UnitTranslation() { Id = 2, UnitId = 1, NameUnit = "Not Found", MoreInfo = "", LanguageId = 2 },
                new UnitTranslation() { Id = 3, UnitId = 2, NameUnit = "Cỡ X", MoreInfo = "", LanguageId = 1 },
                new UnitTranslation() { Id = 4, UnitId = 2, NameUnit = "Size X", MoreInfo = "Size X", LanguageId = 2 });

            var notCustomerId = new Guid("902F60D4-000C-4EC2-BB30-148F1B6547DC");
            var adminId = new Guid("0B64F6F0-9F60-45C9-9E7B-F68CCC3FC57F");
            var quanghikiId = new Guid("5864C4B8-D809-4CF3-B721-FDB7F868CAC1");
            var yukinoId = new Guid("17EC17A9-06B0-4455-81B2-CF49E5626A6F");


            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = notCustomerId,
                    UserName = "nocustomer",
                    NormalizedUserName = "nocustomer",
                    Email = "nocustomer@hiki.studio.com",
                    NormalizedEmail = "nocustomer@hiki.studio.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                    SecurityStamp = string.Empty,
                    FirstName = "No",
                    LastName = "Customer",
                    Dob = new DateTime(1900, 01, 01),
                    UrlImageUser = "",
                    MoreInfo = "Không có thông tin khách hàng",
                    IsActive = true,
                    GenderId = 3
                },
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
                }, 
                new AppUser()
                {
                    Id = quanghikiId,
                    UserName = "quanghiki",
                    NormalizedUserName = "quanghiki",
                    Email = "tranquanghtkbtm@gmail.com",
                    NormalizedEmail = "tranquanghtkbtm@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                    SecurityStamp = string.Empty,
                    FirstName = "Hachiman",
                    LastName = "Hikigaya",
                    Dob = new DateTime(2000, 10, 18),
                    UrlImageUser = "https://64.media.tumblr.com/f3685609f6f9e0f15b70b740380fe0db/85dff69cc547be63-1d/s640x960/a0fa84e4ec96b338ec45f925baccc9619131013c.jpg",
                    MoreInfo = "8man",
                    IsActive = true,
                    GenderId = 1
                }, 
                new AppUser()
                {
                    Id = yukinoId,
                    UserName = "yukino",
                    NormalizedUserName = "yukino",
                    Email = "oregairu@gmail.com",
                    NormalizedEmail = "oregairu@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                    SecurityStamp = string.Empty,
                    FirstName = "Yukino",
                    LastName = "Yukinoshita",
                    Dob = new DateTime(2000, 12, 08),
                    UrlImageUser = "https://64.media.tumblr.com/f3685609f6f9e0f15b70b740380fe0db/85dff69cc547be63-1d/s640x960/a0fa84e4ec96b338ec45f925baccc9619131013c.jpg",
                    MoreInfo = "yukino",
                    IsActive = true,
                    GenderId = 2
                });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid> { RoleId = adminRoleId, UserId = adminId },
                new IdentityUserRole<Guid> { RoleId = staffRoleId, UserId = quanghikiId });

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, IsActive = true, UnitId = 1, DateCreated = DateTime.Now, IsFeatured = true, ViewCount = 0, Stock = 0, OriginalPrice = 100000, Price = 90000, UrlImageCoverProduct = "https://i.pinimg.com/originals/ea/3f/37/ea3f37ad3242d1796f7136741dcebfbd.jpg" },
                new Product() { Id = 2, IsActive = true, UnitId = 1, DateCreated = DateTime.Now, IsFeatured = false, ViewCount = 0, Stock = 0, OriginalPrice = 55000, Price = 47000, UrlImageCoverProduct = "https://coffeebean.com.vn/wp-content/uploads/2019/09/Matcha-green-tea-Affogato-1.png" },
                new Product() { Id = 3, IsActive = true, UnitId = 2, DateCreated = DateTime.Now, IsFeatured = true, ViewCount = 0, Stock = 0, OriginalPrice = 84000, Price = 72000, UrlImageCoverProduct = "https://www.coffeesphere.com/wp-content/uploads/2020/07/what-is-americano.jpeg" });

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

            modelBuilder.Entity<CoffeeTable>().HasData(
                new CoffeeTable() { Id = 1, NameCoffeeTable = "Table 01", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 2, NameCoffeeTable = "Table 02", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 3, NameCoffeeTable = "Table 03", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 4, NameCoffeeTable = "Table 04", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 5, NameCoffeeTable = "Table 05", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 6, NameCoffeeTable = "Table 06", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 7, NameCoffeeTable = "Table 07", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 8, NameCoffeeTable = "Table 08", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 9, NameCoffeeTable = "Table 09", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 10, NameCoffeeTable = "Table 10", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 11, NameCoffeeTable = "Table 11", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 12, NameCoffeeTable = "Table 12", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 13, NameCoffeeTable = "Table 13", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 14, NameCoffeeTable = "Table 14", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 15, NameCoffeeTable = "Table 15", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 16, NameCoffeeTable = "Table 16", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 17, NameCoffeeTable = "Table 17", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 18, NameCoffeeTable = "Table 18", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 19, NameCoffeeTable = "Table 19", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 20, NameCoffeeTable = "Table 20", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null },
                new CoffeeTable() { Id = 21, NameCoffeeTable = "Table 21", IsActive = true, StatusId = 3, AppointmentTime = null, ExpirationTime = null });




        }
    }
}
