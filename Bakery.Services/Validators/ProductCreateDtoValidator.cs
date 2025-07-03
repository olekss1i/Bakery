using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using Bakery.Services.DTO;

namespace Bakery.Services.Validators
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Название обязательно");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Цена должна быть больше 0");
        }
    }
}
