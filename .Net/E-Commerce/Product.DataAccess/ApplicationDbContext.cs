using Microsoft.EntityFrameworkCore;
using Product.Models;

namespace Product.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }

        public DbSet<Products> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Electronics" },
                new Category { CategoryId = 2, CategoryName = "Furniture" }
            );

            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    ProductId = 1,
                    ProductName = "Phones",
                    CategoryId = 1,
                    Price = 55250.00
                },
                new Products
                {
                    ProductId = 2,
                    ProductName = "Sofa",
                    CategoryId = 2,
                    Price = 95000.00
                }
              );

            base.OnModelCreating(modelBuilder);

        }

    }
}