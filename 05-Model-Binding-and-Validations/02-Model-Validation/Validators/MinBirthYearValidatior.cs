using System.ComponentModel.DataAnnotations;

class MinBirthYearValidatior: ValidationAttribute
{
    public int MinAge { get; set; } = 18;

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        int birthYear = (int) value!;
        int currentYear = DateTime.Now.Year;
        if (currentYear - birthYear > MinAge)
        {
            return ValidationResult.Success;
        } else 
        {
            return new ValidationResult($"Age shoul be greater than {MinAge}");
        }
    }
}