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

            // Конфигурация ProductsIngredients — составной ключ
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

            // Конфигурация Feedback
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
    }
}
