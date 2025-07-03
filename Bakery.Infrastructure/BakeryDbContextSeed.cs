using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bakery.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Bakery.Infrastructure
{
    public static class BakeryDbContextSeed
    {
        public static void Seed(this BakeryDbContext context)
        {
        
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    new Customer
                    {
                        FirstName = "Ivan",
                        LastName = "Ivanov",
                        Gender = 'M',
                        Age = 30,
                        PhoneNumber = "+380991112233",
                        CountryId = 1
                    },
                    new Customer
                    {
                        FirstName = "Anna",
                        LastName = "Petrova",
                        Gender = 'F',
                        Age = 25,
                        PhoneNumber = "+380987654321",
                        CountryId = 2
                    }
                );
                context.SaveChanges();
            }

            
        }
    }
}
