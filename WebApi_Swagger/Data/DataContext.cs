using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Swagger.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasData(new List<Product>()
                    {
                        new Product() { Id = 1, Description = "Produto 1", Price = 10 },
                        new Product() { Id = 2, Description = "Produto 2", Price = 20 },
                        new Product() { Id = 3, Description = "Produto 3", Price = 30 },
                        new Product() { Id = 4, Description = "Produto 4", Price = 40 },
                        new Product() { Id = 5, Description = "Produto 5", Price = 50 }
                    });
        }
    }
}