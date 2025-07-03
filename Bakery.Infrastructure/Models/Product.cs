using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bakery.Infrastructure.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Recipe { get; set; }
        public decimal Price { get; set; }

        public ICollection<ProductsIngredients> ProductsIngredients { get; set; } = new List<ProductsIngredients>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}