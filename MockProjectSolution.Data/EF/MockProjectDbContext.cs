using Microsoft.EntityFrameworkCore;
using MockProjectSolution.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockProjectSolution.Data.EF
{
    public class MockProjectDbContext : DbContext
    {
        public MockProjectDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating( ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

        }
        
    }
}
