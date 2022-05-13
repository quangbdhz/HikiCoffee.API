using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikiCoffee.Data.EF
{
    public class HikiCoffeeDbContextFactory : IDesignTimeDbContextFactory<HikiCoffeeDbContext>
    {
        public HikiCoffeeDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("HikiCoffeeDb");

            var optionsBuilder = new DbContextOptionsBuilder<HikiCoffeeDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new HikiCoffeeDbContext(optionsBuilder.Options);
        }
    }
}
