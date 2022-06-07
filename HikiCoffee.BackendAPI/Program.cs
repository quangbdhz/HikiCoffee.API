using FluentValidation.AspNetCore;
using HikiCoffee.Application.BillInfos;
using HikiCoffee.Application.Bills;
using HikiCoffee.Application.Categories;
using HikiCoffee.Application.CategoryTranslations;
using HikiCoffee.Application.CoffeeTables;
using HikiCoffee.Application.Genders;
using HikiCoffee.Application.ImportProducts;
using HikiCoffee.Application.Languages;
using HikiCoffee.Application.MailConfirms;
using HikiCoffee.Application.Products;
using HikiCoffee.Application.ProductTranslations;
using HikiCoffee.Application.Statuses;
using HikiCoffee.Application.StatusTransaltions;
using HikiCoffee.Application.UnitTranslations;
using HikiCoffee.Application.Users;
using HikiCoffee.Application.Uses;
using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.ViewModels.Users.UserRequestValidator;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);



var connectionString = builder.Configuration.GetConnectionString("HikiCoffeeDb");
builder.Services.AddDbContext<HikiCoffeeDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<HikiCoffeeDbContext>()
                .AddDefaultTokenProviders();



// Add services to the container.

builder.Services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
builder.Services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
builder.Services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ILanguageService, LanguageService>();
builder.Services.AddTransient<IMailConfirmService, MailConfirmService>();
builder.Services.AddTransient<IProducService, ProductService>();
builder.Services.AddTransient<IProductTranslationService, ProductTranslationService>();
builder.Services.AddTransient<IUnitService, UnitService>();
builder.Services.AddTransient<IUnitTranslationService, UnitTranslationService>();
builder.Services.AddTransient<IImportProductService, ImportProductService>();
builder.Services.AddTransient<ICoffeeTableService, CoffeeTableService>();
builder.Services.AddTransient<IBillInfoService, BillInfoService>();
builder.Services.AddTransient<IBillService, BillService>();
builder.Services.AddTransient<IGenderService, GenderService>();
builder.Services.AddTransient<IStatusService, StatusService>();
builder.Services.AddTransient<IStatusTranslationService, StatusTranslationService>();
builder.Services.AddTransient<ICategoryTranslationService, CategoryTranslationService>();


//builder.Services.AddControllers();
builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer"},
                          Scheme = "oauth2", Name = "Bearer", In = ParameterLocation.Header, }, new List<string>()  }
    });
});

string issuer = builder.Configuration.GetSection("Tokens:Issuer").Value;
string signingKey = builder.Configuration.GetSection("Tokens:Key").Value;
byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateAudience = true,
        ValidAudience = issuer,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = System.TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();