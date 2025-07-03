using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Infrastructure.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IProductsRepository Products { get; }
        Task<int> SaveChangesAsync();
    }
}
