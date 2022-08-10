using Entities.Dtos.Admin;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AdminForRegisterDtoValidator : AbstractValidator<AdminForRegisterDto>
    {
        public AdminForRegisterDtoValidator()
        {
            RuleFor(a => a.UserName).NotEmpty();
            RuleFor(a => a.Password).NotEmpty();
        }
    }
}