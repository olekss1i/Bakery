using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Bakery.Infrastructure
{
    public class BakeryDbContextFactory : IDesignTimeDbContextFactory<BakeryDbContext>
    {
        public BakeryDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BakeryDbContext>();
       
            optionsBuilder.UseSqlServer("YourConnectionStringHere");

            return new BakeryDbContext(optionsBuilder.Options);
        }
    }
}
