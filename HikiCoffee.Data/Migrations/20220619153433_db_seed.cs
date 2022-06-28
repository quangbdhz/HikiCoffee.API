using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiCoffee.Data.Migrations
{
    public partial class db_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    UrlImageCoverCategory = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    IsShowOnHome = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameGender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    NameLanguage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSuplier = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    MoreInfo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrlImageUser = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    MoreInfo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    RefreshToken = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUsers_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    NameCategory = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SeoTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SeoAlias = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    LanguageId = table.Column<int>(type: "int", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryTranslations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCoffeeTable = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AppointmentTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoffeeTables_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    NameStatus = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatusTranslations_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlImageCoverProduct = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ViewCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Uses_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Uses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UnitTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    NameUnit = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MoreInfo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    LanguageId = table.Column<int>(type: "int", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitTranslations_Uses_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Uses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoffeeTableId = table.Column<int>(type: "int", nullable: false),
                    AppointmentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoreInfo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentSchedules_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentSchedules_CoffeeTables_CoffeeTableId",
                        column: x => x.CoffeeTableId,
                        principalTable: "CoffeeTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentSchedules_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoffeeTabelId = table.Column<int>(type: "int", nullable: false),
                    UserPaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCheckOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalPayPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_AppUsers_UserPaymentId",
                        column: x => x.UserPaymentId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bills_CoffeeTables_CoffeeTabelId",
                        column: x => x.CoffeeTabelId,
                        principalTable: "CoffeeTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bills_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImportProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdImportProduct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateImportProduct = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PriceImportProduct = table.Column<int>(type: "int", nullable: false),
                    SuplierId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportProducts_AppUsers_UserIdImportProduct",
                        column: x => x.UserIdImportProduct,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportProducts_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImportProducts_Supliers_SuplierId",
                        column: x => x.SuplierId,
                        principalTable: "Supliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UrlImageProduct = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInCategories", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductInCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    NameProduct = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Details = table.Column<string>(type: "nvarchar(3800)", maxLength: 3800, nullable: true),
                    SeoDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SeoTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SeoAlias = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LanguageId = table.Column<int>(type: "int", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTranslations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillInfos_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillInfos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), "11603e7a-d6da-4069-b881-855df88ca2e9", "Customer role", "customer", "customer" },
                    { new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), "5d4bce45-f815-4d6e-95f3-18940c857139", "Staff role", "staff", "staff" },
                    { new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), "3392e45a-2519-4cf5-8ed5-6e7d6b8137e9", "Administrator role", "admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("5864c4b8-d809-4cf3-b721-fdb7f868cac1") }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsActive", "IsShowOnHome", "ParentId", "SortOrder", "UrlImageCoverCategory" },
                values: new object[,]
                {
                    { 1, true, true, null, 1, "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1655137566/HikiCoffee/Image_Category/Coffee_adqju2.png" },
                    { 2, true, true, null, 1, "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1655137567/HikiCoffee/Image_Category/Tea_ri0xmh.png" },
                    { 3, true, true, null, 1, "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1655137566/HikiCoffee/Image_Category/Capuchino_nofwkm.png" },
                    { 4, true, true, null, 1, "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1655137566/HikiCoffee/Image_Category/Beer_lxd9sc.png" },
                    { 5, true, true, null, 1, "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1655137566/HikiCoffee/Image_Category/Wine_ufhg6w.png" },
                    { 6, true, true, null, 1, "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1655392394/HikiCoffee/Image_Category/Juice_tn0vyi.png" },
                    { 7, true, true, null, 1, "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1655392394/HikiCoffee/Image_Category/Ice_Cream_ftsjti.png" },
                    { 8, true, true, null, 1, "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1655392394/HikiCoffee/Image_Category/Milktea_pkf5s5.png" },
                    { 9, true, true, null, 1, "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1655392394/HikiCoffee/Image_Category/Milk_siwgx5.png" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "IsActive", "NameGender" },
                values: new object[,]
                {
                    { 1, true, "Male" },
                    { 2, true, "Female" },
                    { 3, true, "Custom" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "IsDefault", "NameLanguage" },
                values: new object[] { 1, "vi-VN", true, "Tiếng Việt" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "NameLanguage" },
                values: new object[] { 2, "en-US", "English" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "DateCreated", "IsActive" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 19, 22, 34, 32, 584, DateTimeKind.Local).AddTicks(5785), true },
                    { 2, new DateTime(2022, 6, 19, 22, 34, 32, 584, DateTimeKind.Local).AddTicks(5800), true },
                    { 3, new DateTime(2022, 6, 19, 22, 34, 32, 584, DateTimeKind.Local).AddTicks(5801), true },
                    { 4, new DateTime(2022, 6, 19, 22, 34, 32, 584, DateTimeKind.Local).AddTicks(5802), true },
                    { 5, new DateTime(2022, 6, 19, 22, 34, 32, 584, DateTimeKind.Local).AddTicks(5803), true }
                });

            migrationBuilder.InsertData(
                table: "Uses",
                columns: new[] { "Id", "IsActive" },
                values: new object[,]
                {
                    { 1, true },
                    { 2, true }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "GenderId", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MoreInfo", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenCreated", "TokenExpires", "TwoFactorEnabled", "UrlImageUser", "UserName" },
                values: new object[,]
                {
                    { new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), 0, "df5527f2-a9a3-4907-830a-3011dbeebc28", new DateTime(2001, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "tranquangbhdz@gmail.com", true, "Tran", 1, true, "Quang", false, null, "Chùm", "tranquangbhdz@gmail.com", "admin", "AQAAAAEAACcQAAAAEBRYnjsB30nFo7CuZs8MGp8JIxVKZL8LAvfLsVWTHL7XUtMHF27Cc851ewrjUCUeiQ==", null, false, null, "", null, null, false, "https://64.media.tumblr.com/f3685609f6f9e0f15b70b740380fe0db/85dff69cc547be63-1d/s640x960/a0fa84e4ec96b338ec45f925baccc9619131013c.jpg", "admin" },
                    { new Guid("17ec17a9-06b0-4455-81b2-cf49e5626a6f"), 0, "d3947014-34b9-4cc1-a18a-e397857b10c2", new DateTime(2000, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "oregairu@gmail.com", true, "Yukino", 2, true, "Yukinoshita", false, null, "yukino", "oregairu@gmail.com", "yukino", "AQAAAAEAACcQAAAAEHxeRLcB0Wf+UJN0BAu3HImwNfp4T87e+HSZkLcFuuzXwbE9ebaJWM7AczCEzOVbiA==", null, false, null, "", null, null, false, "https://64.media.tumblr.com/f3685609f6f9e0f15b70b740380fe0db/85dff69cc547be63-1d/s640x960/a0fa84e4ec96b338ec45f925baccc9619131013c.jpg", "yukino" },
                    { new Guid("5864c4b8-d809-4cf3-b721-fdb7f868cac1"), 0, "87583a29-95ec-4ef3-bb74-e4767b46c198", new DateTime(2000, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "tranquanghtkbtm@gmail.com", true, "Hachiman", 1, true, "Hikigaya", false, null, "8man", "tranquanghtkbtm@gmail.com", "quanghiki", "AQAAAAEAACcQAAAAEG8ZkN32NOT4BU/FfLM/AapLicGFUQks4UnjEamxelMaah1qTVHOZCnUi7gVJZB7Aw==", null, false, null, "", null, null, false, "https://64.media.tumblr.com/f3685609f6f9e0f15b70b740380fe0db/85dff69cc547be63-1d/s640x960/a0fa84e4ec96b338ec45f925baccc9619131013c.jpg", "quanghiki" },
                    { new Guid("902f60d4-000c-4ec2-bb30-148f1b6547dc"), 0, "62e9cc49-8e96-4743-8c7f-c6825f2940fd", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nocustomer@hiki.studio.com", true, "No", 3, true, "Customer", false, null, "Không có thông tin khách hàng", "nocustomer@hiki.studio.com", "nocustomer", "AQAAAAEAACcQAAAAEMd2KV+qeezty/WasYUQ911jddynOFylppc+fWE7kwz0f4GObNV1unbK6FQM7T/08g==", null, false, null, "", null, null, false, "", "nocustomer" }
                });

            migrationBuilder.InsertData(
                table: "CategoryTranslations",
                columns: new[] { "Id", "CategoryId", "LanguageId", "NameCategory", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 1, 1, 2, "Coffee", "/coffee-black-381831", "Good", "Product Coffee" },
                    { 2, 1, 1, "Cà Phê", "/ca-phe-den-838442", "Good Drink", "Sản phầm cà phê" },
                    { 3, 2, 2, "Tea", "/tea-342242", "Good", "Product Tea" },
                    { 4, 2, 1, "Trà", "/tra-837113", "Good Drink", "Sản phầm trà" },
                    { 5, 3, 2, "Capuchino", "/capuchino-156342", "Good", "Product Capuchino" },
                    { 6, 3, 1, "Capuchino", "/capuchino-537342", "Good Drink", "Sản phầm Capuchino" },
                    { 7, 4, 2, "Beer", "/beer-942752", "Good", "Product Beer" },
                    { 8, 4, 1, "Bia", "/bia-821964", "Good Drink", "Sản phầm bia" },
                    { 9, 5, 2, "Wine", "/wine-105824", "Good", "Product Wine" },
                    { 10, 5, 1, "Rược", "/ruoc-347134", "Good Drink", "Sản phầm rược" },
                    { 11, 6, 2, "Juice", "/juice-942712", "Good", "Product Juice" },
                    { 12, 6, 1, "Nước ép", "/nuoc-ep-413521", "Good Drink", "Sản phầm nước ép" },
                    { 13, 7, 2, "Ice Cream", "/ice-cream-105824", "Good", "Product Ice Cream" },
                    { 14, 7, 1, "Kem", "/kem-521564", "Good Drink", "Sản phầm kem" },
                    { 15, 8, 2, "Milk tea", "/milk-tea-941712", "Good", "Product Milk Tea" },
                    { 16, 8, 1, "Trà sữa", "/tra-sua-983343", "Good Drink", "Sản phầm trà sữa" },
                    { 17, 9, 2, "Milk", "/milk-428413", "Good", "Product Milk" },
                    { 18, 9, 1, "Sữa", "/sua-347134", "Good Drink", "Sản phầm sữa" }
                });

            migrationBuilder.InsertData(
                table: "CoffeeTables",
                columns: new[] { "Id", "AppointmentTime", "ExpirationTime", "IsActive", "NameCoffeeTable", "StatusId" },
                values: new object[,]
                {
                    { 1, null, null, true, "Table 01", 3 },
                    { 2, null, null, true, "Table 02", 3 },
                    { 3, null, null, true, "Table 03", 3 },
                    { 4, null, null, true, "Table 04", 3 },
                    { 5, null, null, true, "Table 05", 3 },
                    { 6, null, null, true, "Table 06", 3 },
                    { 7, null, null, true, "Table 07", 3 },
                    { 8, null, null, true, "Table 08", 3 },
                    { 9, null, null, true, "Table 09", 3 },
                    { 10, null, null, true, "Table 10", 3 },
                    { 11, null, null, true, "Table 11", 3 },
                    { 12, null, null, true, "Table 12", 3 },
                    { 13, null, null, true, "Table 13", 3 },
                    { 14, null, null, true, "Table 14", 3 },
                    { 15, null, null, true, "Table 15", 3 },
                    { 16, null, null, true, "Table 16", 3 },
                    { 17, null, null, true, "Table 17", 3 },
                    { 18, null, null, true, "Table 18", 3 },
                    { 19, null, null, true, "Table 19", 3 },
                    { 20, null, null, true, "Table 20", 3 }
                });

            migrationBuilder.InsertData(
                table: "CoffeeTables",
                columns: new[] { "Id", "AppointmentTime", "ExpirationTime", "IsActive", "NameCoffeeTable", "StatusId" },
                values: new object[] { 21, null, null, true, "Table 21", 3 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateCreated", "IsActive", "IsFeatured", "OriginalPrice", "Price", "UnitId", "UrlImageCoverProduct" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 19, 22, 34, 32, 623, DateTimeKind.Local).AddTicks(7150), true, true, 100000m, 90000m, 1, "https://i.pinimg.com/originals/ea/3f/37/ea3f37ad3242d1796f7136741dcebfbd.jpg" },
                    { 2, new DateTime(2022, 6, 19, 22, 34, 32, 623, DateTimeKind.Local).AddTicks(7164), true, false, 55000m, 47000m, 1, "https://coffeebean.com.vn/wp-content/uploads/2019/09/Matcha-green-tea-Affogato-1.png" },
                    { 3, new DateTime(2022, 6, 19, 22, 34, 32, 623, DateTimeKind.Local).AddTicks(7167), true, true, 84000m, 72000m, 2, "https://www.coffeesphere.com/wp-content/uploads/2020/07/what-is-americano.jpeg" }
                });

            migrationBuilder.InsertData(
                table: "StatusTranslations",
                columns: new[] { "Id", "LanguageId", "NameStatus", "StatusId" },
                values: new object[,]
                {
                    { 1, 1, "Đã Thanh Toán", 1 },
                    { 2, 2, "Paid", 1 },
                    { 3, 1, "Chưa Thanh Toán", 2 },
                    { 4, 2, "Unpaid", 2 },
                    { 5, 1, "Bàn Còn Trống", 3 },
                    { 6, 2, "Tables Are Empty", 3 },
                    { 7, 1, "Bàn Đang Sử Dụng", 4 },
                    { 8, 2, "Table In Use", 4 },
                    { 9, 1, "Hóa Đơn Đã Được Gộp", 5 },
                    { 10, 2, "Invoices Consolidated", 5 }
                });

            migrationBuilder.InsertData(
                table: "UnitTranslations",
                columns: new[] { "Id", "LanguageId", "MoreInfo", "NameUnit", "UnitId" },
                values: new object[,]
                {
                    { 1, 1, "", "Không có", 1 },
                    { 2, 2, "", "Not Found", 1 },
                    { 3, 1, "", "Cỡ X", 2 },
                    { 4, 2, "Size X", "Size X", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Caption", "DateCreated", "FileSize", "ProductId", "SortOrder", "UrlImageProduct" },
                values: new object[,]
                {
                    { 1, "image 1", new DateTime(2022, 6, 19, 22, 34, 32, 623, DateTimeKind.Local).AddTicks(7292), 0L, 1, 0, "https://icdn.dantri.com.vn/thumb_w/640/2021/03/04/vi-ca-phe-den-het-nhu-vi-cuoc-songdocx-1614866315610.png" },
                    { 2, "image 2", new DateTime(2022, 6, 19, 22, 34, 32, 623, DateTimeKind.Local).AddTicks(7293), 0L, 1, 0, "https://artcoffee.vn/wp-content/uploads/2020/09/8-loi-ich-to-lon-cua-viec-uong-ca-phe-den-nguyen-chat-khong-duong.jpg" },
                    { 3, "image 3", new DateTime(2022, 6, 19, 22, 34, 32, 623, DateTimeKind.Local).AddTicks(7295), 0L, 1, 0, "https://doisongbiz.com/wp-content/uploads/2017/04/bi-quyet-giam-can-nhanh-chong-bang-cafe-den.jpg" },
                    { 4, "image 1", new DateTime(2022, 6, 19, 22, 34, 32, 623, DateTimeKind.Local).AddTicks(7296), 0L, 2, 0, "https://images.japancentre.com/recipes/pics/16/main/matcha-latte.jpg?1469572822" },
                    { 5, "image 2", new DateTime(2022, 6, 19, 22, 34, 32, 623, DateTimeKind.Local).AddTicks(7297), 0L, 2, 0, "https://gimmedelicious.com/wp-content/uploads/2018/03/Iced-Matcha-Latte2.jpg" },
                    { 6, "image 1", new DateTime(2022, 6, 19, 22, 34, 32, 623, DateTimeKind.Local).AddTicks(7298), 0L, 3, 0, "https://cdn.tgdd.vn/2021/11/CookDish/americano-la-gi-nguon-goc-cach-pha-americano-don-gian-va-avt-1200x676.jpg" }
                });

            migrationBuilder.InsertData(
                table: "ProductInCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductTranslations",
                columns: new[] { "Id", "Description", "Details", "LanguageId", "NameProduct", "ProductId", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 1, "Cà phê đen thơm ngon từng vị", "<h2><span style='font-size: 95%;'>Cà phê đen đóng chai nguyên chất tại Hà Nội</span></h2><p>Mua<strong> cà phê đen đóng chai </strong>online vào thời điểm này đang là lựa chọn số một cho những người yêu thích cà phê. Tình hình chống dịch của Hà Nội đang rất căng thẳng. Hàng quán thì đóng cửa, đi lại bị hạn chế, và không được tụ tập đông người. Nên cách tốt nhất vẫn là ngồi ở nhà hay ở chỗ làm và mua online một ly cà phê để thưởng thức</p>", 1, "Cà phê đen", 1, "/ca-phe-den-193412", "Cafe đen bạn của mọi nhà", "Cafe đen đậm vị thơm ngon" },
                    { 2, "Black Coffee Is The Best", "Black Coffee", 2, "Black Coffee", 1, "/black-coffee-918413", "Coffee", "Black Coffee" },
                    { 3, "Trà xanh siêu ngon", "Trà xanh Matcha siêu <strong>thơm</strong> ngon", 1, "Trà xanh Matcha", 2, "/tra-xanh-matcha-741413", "Trà xanh Matcha", "Trà xanh Matcha" },
                    { 4, "Matcha Green Tea", "Matcha Green Tea Is The Best", 2, "Matcha Green Tea", 2, "/matcha-green-tea-414131", "Matcha Green Tea", "Matcha Green Tea" },
                    { 5, "Cà phê Americano", "Cà phê Americano Ngon", 1, "Cà phê Americano", 3, "/ca-phe-americano-371471", "Cà phê Americano", "Cà phê Americano" },
                    { 6, "Americano", "Americano", 2, "Americano", 3, "/americano-347272", "Americano", "Americano" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedules_CoffeeTableId",
                table: "AppointmentSchedules",
                column: "CoffeeTableId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedules_StatusId",
                table: "AppointmentSchedules",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedules_UserId",
                table: "AppointmentSchedules",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_GenderId",
                table: "AppUsers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_BillInfos_BillId",
                table: "BillInfos",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillInfos_ProductId",
                table: "BillInfos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CoffeeTabelId",
                table: "Bills",
                column: "CoffeeTabelId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_StatusId",
                table: "Bills",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_UserPaymentId",
                table: "Bills",
                column: "UserPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_CategoryId",
                table: "CategoryTranslations",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_LanguageId",
                table: "CategoryTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeTables_StatusId",
                table: "CoffeeTables",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportProducts_ProductId",
                table: "ImportProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportProducts_StatusId",
                table: "ImportProducts",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportProducts_SuplierId",
                table: "ImportProducts",
                column: "SuplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportProducts_UserIdImportProduct",
                table: "ImportProducts",
                column: "UserIdImportProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInCategories_ProductId",
                table: "ProductInCategories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitId",
                table: "Products",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_LanguageId",
                table: "ProductTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_ProductId",
                table: "ProductTranslations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTranslations_LanguageId",
                table: "StatusTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTranslations_StatusId",
                table: "StatusTranslations",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitTranslations_LanguageId",
                table: "UnitTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitTranslations_UnitId",
                table: "UnitTranslations",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentSchedules");

            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "BillInfos");

            migrationBuilder.DropTable(
                name: "CategoryTranslations");

            migrationBuilder.DropTable(
                name: "ImportProducts");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductInCategories");

            migrationBuilder.DropTable(
                name: "ProductTranslations");

            migrationBuilder.DropTable(
                name: "StatusTranslations");

            migrationBuilder.DropTable(
                name: "UnitTranslations");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Supliers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "CoffeeTables");

            migrationBuilder.DropTable(
                name: "Uses");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
