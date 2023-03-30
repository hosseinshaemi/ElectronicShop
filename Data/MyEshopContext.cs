using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyEshop.Models;
namespace MyEshop.Data;

public class MyEshopContext : DbContext
{
    #nullable disable
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public string DbPath { get; set; }
    public MyEshopContext()
    {
        DbPath = Path.Combine(Directory.GetCurrentDirectory(), "database.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryToProduct>().HasKey(t => new { t.ProductId, t.CategoryId });

        /* modelBuilder.Entity<Product>(
            p => {
                p.HasKey(w => w.Id);
                p.OwnsOne<Item>(w => w.Item);
                p.HasOne<Item>(w => w.Item).WithOne(w => w.Product)
                .HasForeignKey<Item>(w => w.Id);
            }
        ); */

        modelBuilder.Entity<Item>(
            p => {
                p.Property(w => w.Price).HasColumnType("Money");
                p.HasKey(w => w.Id);
            }
        );

        #region SeedData
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Asp.Net Core",
                Description = "This is first course",
            },
            new Category
            {
                Id = 2,
                Name = "React js",
                Description = "This is second course",
            },
            new Category
            {
                Id = 3,
                Name = "Vue js",
                Description = "This is third course",
            },
            new Category
            {
                Id = 4,
                Name = "Express js",
                Description = "This is fourth course",
            }
        );

        modelBuilder.Entity<Item>().HasData(
            new Item{
                Id = 1,
                Price = 854.0M,
                QuantityInStock = 5,
            },
            new Item{
                Id = 2,
                Price = 3302.0M,
                QuantityInStock = 8,
            },
            new Item{
                Id = 3,
                Price = 2580.0M,
                QuantityInStock = 3,
            }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product{
                Id = 1,
                ItemId = 1,
                Name = "Product 1",
                Description = "This is product 1 and is very good",
            },
            new Product{
                Id = 2,
                ItemId = 2,
                Name = "Product 2",
                Description = "This is product 2 and is very good",
            },
            new Product{
                Id = 3,
                ItemId = 3,
                Name = "Product 3",
                Description = "This is product 3 and is very good",
            }
        );

        modelBuilder.Entity<CategoryToProduct>().HasData(
            new CategoryToProduct{ CategoryId = 1, ProductId = 1, },
            new CategoryToProduct{ CategoryId = 2, ProductId = 1, },
            new CategoryToProduct{ CategoryId = 3, ProductId = 1, },
            new CategoryToProduct{ CategoryId = 4, ProductId = 1, },
            new CategoryToProduct{ CategoryId = 1, ProductId = 2, },
            new CategoryToProduct{ CategoryId = 2, ProductId = 2, },
            new CategoryToProduct{ CategoryId = 3, ProductId = 2, },
            new CategoryToProduct{ CategoryId = 4, ProductId = 2, },
            new CategoryToProduct{ CategoryId = 1, ProductId = 3, },
            new CategoryToProduct{ CategoryId = 2, ProductId = 3, },
            new CategoryToProduct{ CategoryId = 3, ProductId = 3, },
            new CategoryToProduct{ CategoryId = 4, ProductId = 3, }
        );

        #endregion
        base.OnModelCreating(modelBuilder);
    }
}
