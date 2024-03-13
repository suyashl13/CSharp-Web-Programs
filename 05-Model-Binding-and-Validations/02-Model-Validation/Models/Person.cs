using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

public class Person
{
    public Guid PersonId { get; set; }

    [Required(ErrorMessage = "{0} is required field.")]
    [Display(Name = "Firt Name")]
    [StringLength(maximumLength: 40, MinimumLength = 3)]
    public String? Name { get; set; }
    
    [Required]
    [EmailAddress]
    public String? Email { get; set; }
    
    [Required]
    public String? Password { get; set; }

    [Required(ErrorMessage = "No. De de re baba!!!")]
    [Phone]
    public String? Phone { get; set; }

    [BindNever]
    // [Required]
    // [MinBirthYearValidatior(MinAge = 18)]
    public int? YearOfBirth {get; set;}
}