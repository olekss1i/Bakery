using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Infrastructure.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public string Comment { get; set; } = string.Empty;   
        public int Rating { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
