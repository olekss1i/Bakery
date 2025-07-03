using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bakery.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BakeryDbContext _context;
        private IProductsRepository? _products;

        public UnitOfWork(BakeryDbContext context)
        {
            _context = context;
        }

        public IProductsRepository Products => _products ??= new ProductsRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
