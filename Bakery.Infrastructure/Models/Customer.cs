using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Infrastructure.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public char Gender { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;

        
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
