using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace COBAShop.Data.EF
{
    public class COBAShopDbContextFactory : IDesignTimeDbContextFactory<COBAShopDbContext>
    {
        public COBAShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("COBAShopDatabase");

            var optionsBuilder = new DbContextOptionsBuilder<COBAShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new COBAShopDbContext(optionsBuilder.Options);
        }
    }
}