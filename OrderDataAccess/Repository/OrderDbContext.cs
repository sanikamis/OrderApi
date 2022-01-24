using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderDataAccess.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrderDataAccess.Repository
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext()
        {
        }

        public OrderDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("ConnStr");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
