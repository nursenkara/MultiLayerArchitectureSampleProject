using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                string errorMessages = "Validation Errors: ";
                foreach (var error in result.Errors)
                {
                    errorMessages += error.ErrorMessage;
                }
                throw new ValidationException(errorMessages);
            }
        }
    }
}