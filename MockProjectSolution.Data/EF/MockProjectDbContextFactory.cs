using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MockProjectSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace eShopSolution.Data.EF
{
    public class MockProjectDbContextFactory : IDesignTimeDbContextFactory<MockProjectDbContext>
    {
        public MockProjectDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("MockProjectSolution");

            var optionsBuilder = new DbContextOptionsBuilder<MockProjectDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new MockProjectDbContext(optionsBuilder.Options);
        }
    }
}