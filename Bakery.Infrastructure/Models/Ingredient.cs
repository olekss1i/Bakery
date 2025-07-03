using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Infrastructure.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public int OriginCountryId { get; set; }
        public Country OriginCountry { get; set; } = null!;

        public int DistributorId { get; set; }
        public Distributor Distributor { get; set; } = null!;

        public ICollection<ProductsIngredients> ProductsIngredients { get; set; } = new List<ProductsIngredients>();
    }
}