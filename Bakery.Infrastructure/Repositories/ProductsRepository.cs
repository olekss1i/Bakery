using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bakery.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Infrastructure.Repositories
{
    public interface IProductsRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsWithIngredientsAsync();
        Task<Product?> GetProductWithIngredientsByIdAsync(int id);
    }

    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        public ProductsRepository(BakeryDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsWithIngredientsAsync()
        {
            return await _dbSet
                .Include(p => p.ProductsIngredients)
                    .ThenInclude(pi => pi.Ingredient)
                .ToListAsync();
        }

        public async Task<Product?> GetProductWithIngredientsByIdAsync(int id)
        {
            return await _dbSet
                .Include(p => p.ProductsIngredients)
                    .ThenInclude(pi => pi.Ingredient)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

