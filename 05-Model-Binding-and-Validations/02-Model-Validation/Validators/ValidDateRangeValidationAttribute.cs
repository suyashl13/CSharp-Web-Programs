using System.ComponentModel.DataAnnotations;
using System.Reflection;

class ValidDateRangeValidationAttribute: ValidationAttribute
{
    public String DefaultErrorMessage { get; set; } = "From Date Should be greater than to date";
    public required String OtherPropertyName { get; set; }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        DateTime toDate = Convert.ToDateTime(value);
        PropertyInfo? other = validationContext.ObjectType.GetProperty(OtherPropertyName);

        if (other != null)
        {
            DateTime fromDate = Convert.ToDateTime(other.GetValue(validationContext.ObjectInstance));

            if (toDate < fromDate)
            {
                return new ValidationResult(DefaultErrorMessage, [fromDate.ToString(), toDate.ToString()]);
            } else
            {
                return ValidationResult.Success;   
            }

        } return null;
    }
}