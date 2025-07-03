using Bakery.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Bakery.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Bakery.Infrastructure
{
    public class BakeryDbContext : DbContext
    {
        public BakeryDbContext(DbContextOptions<BakeryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;
        public DbSet<ProductsIngredients> ProductsIngredients { get; set; } = null!;
        public DbSet<Feedback> Feedbacks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductsIngredients>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });

            modelBuilder.Entity<ProductsIngredients>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductsIngredients)
                .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductsIngredients>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(i => i.ProductsIngredients)
                .HasForeignKey(pi => pi.IngredientId);

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(f => f.Id);

                entity.Property(f => f.Comment)
                      .IsRequired()
                      .HasMaxLength(1000);

                entity.Property(f => f.Rating)
                      .IsRequired();

                entity.Property(f => f.CreatedAt)
                      .HasDefaultValueSql("GETDATE()");

                entity.HasOne(f => f.Customer)
                      .WithMany(c => c.Feedbacks)
                      .HasForeignKey(f => f.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(f => f.Product)
                      .WithMany(p => p.Feedbacks)
                      .HasForeignKey(f => f.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.ToTable(tb => tb.HasCheckConstraint("CK_Feedback_Rating", "Rating >= 1 AND Rating <= 5"));
            });
        }

        public static void SeedData(BakeryDbContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(new[]
                {
                    new Product { Name = "Bread", Description = "Fresh bread", Price = 20 },
                    new Product { Name = "Cake", Description = "Chocolate cake", Price = 50 },
                    new Product { Name = "Pie", Description = "Apple pie", Price = 35 },
                });
            }

            if (!context.Ingredients.Any())
            {
                context.Ingredients.AddRange(new[]
                {
                    new Ingredient { Name = "Flour" },
                    new Ingredient { Name = "Sugar" },
                    new Ingredient { Name = "Butter" },
                });
            }

            if (!context.Customers.Any())
            {
                context.Customers.Add(new Customer { Name = "John Doe", Email = "john@example.com" });
            }

            context.SaveChanges();
        }
    }
}
