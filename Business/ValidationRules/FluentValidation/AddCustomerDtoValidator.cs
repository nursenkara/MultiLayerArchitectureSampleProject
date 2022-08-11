using Entities.Dtos.Customers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AddCustomerDtoValidator : AbstractValidator<AddCustomerDto>
    {
        public AddCustomerDtoValidator()
        {
            RuleFor(c => c.TCKN).NotEmpty();
            RuleFor(c => c.TCKN).Length(11, 11);
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Surname).NotEmpty();
            RuleFor(c => c.Address).NotEmpty();
            RuleFor(c => c.City).NotEmpty();
            RuleFor(c => c.District).NotEmpty();
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.Telephone).NotEmpty();
        }

    }
}
