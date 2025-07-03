using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Infrastructure.Models
{
    public class Distributor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? AddressText { get; set; }
        public string? Summary { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;

        public ICollection<Ingredient>? Ingredients { get; set; }
    }
}
