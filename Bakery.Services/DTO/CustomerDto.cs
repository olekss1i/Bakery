using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Services.DTO
{
    public class CustomerDto
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public char Gender { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public int CountryId { get; set; }
    }
}