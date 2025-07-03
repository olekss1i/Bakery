using System;
using System.Collections.Generic;

namespace Bakery.Infrastructure.Models
{
    public class Customer
    {
        public int Id { get; set; }

       
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Name
        {
            get => $"{FirstName} {LastName}";
            set
            {
                var parts = value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                FirstName = parts[0];
                LastName = parts.Length > 1 ? parts[1] : "";
            }
        }

        public char Gender { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;

        public string Email { get; set; } = null!;

        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}


