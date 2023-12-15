using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestVPEF.Lib.DTO;

namespace TechTestVPEF.Engine.Validator
{
    public class OrderValidator : AbstractValidator<OrderDTO>
    {
        public OrderValidator()
        {
            RuleFor(x => x.CustomerRef).Length(1, 50).WithMessage("Reference must be between 1 and 50 characters");

            RuleFor(x => x.Customer)
            .NotNull()
            .SetValidator(new CustomerValidator());

            RuleForEach(x => x.Lines)
                .NotNull()
                .SetValidator(new OrderLineValidator());

            RuleFor(x => x).Must(x => x.RequiredDate > DateTime.Now.AddDays(1)).WithMessage("Required date must be at least tomorrow");
        }
    }
}
