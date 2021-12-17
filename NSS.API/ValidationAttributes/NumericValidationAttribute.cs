using System.ComponentModel.DataAnnotations;

namespace notification_scheduling_system.ValidationAttributes
{
    public class NumericValidationAttribute : ValidationAttribute
    {
        private const string NumericRegexPattern = "^[0-9]*$";

        private readonly RegularExpressionAttribute
            regexValidator = new RegularExpressionAttribute(NumericRegexPattern);

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var isValid = regexValidator.IsValid(value);

            return !isValid
                ? new ValidationResult(
                    $"The field {validationContext.DisplayName} must be numeric-only digits")
                : ValidationResult.Success;
        }
    }
}