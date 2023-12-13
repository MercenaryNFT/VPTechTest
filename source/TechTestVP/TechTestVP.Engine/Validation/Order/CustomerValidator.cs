using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestVP.Lib.DTOs;

namespace TechTestVP.Engine.Validation.Order
{
    public class CustomerValidator : AbstractValidator<CustomerDTO>
    {
        public CustomerValidator() 
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Product Id must be supplied");
        }
    }
}
