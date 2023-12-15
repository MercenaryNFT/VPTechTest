using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestVPEF.Lib.DTO;

namespace TechTestVPEF.Engine.Validator
{
    public class OrderLineValidator : AbstractValidator<OrderLineDTO>
    {
        public OrderLineValidator()
        {
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity minimum is 1");
            RuleFor(x => x.ProductId).NotNull().WithMessage("Product Id must be supplied");
            RuleFor(x => x.UnitOfMeasure).IsInEnum().WithMessage("Unit of measure is invalid");
        }
    }
}
