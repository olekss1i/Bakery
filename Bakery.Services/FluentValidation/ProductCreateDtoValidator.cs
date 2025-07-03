using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bakery.Services.DTO;
using FluentValidation;

namespace Bakery.Services.Validators
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().MaximumLength(25);
            RuleFor(p => p.Description).MaximumLength(250);
            RuleFor(p => p.Price).GreaterThan(0);
        }
    }
}

