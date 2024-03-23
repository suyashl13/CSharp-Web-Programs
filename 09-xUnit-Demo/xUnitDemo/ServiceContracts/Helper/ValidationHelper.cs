using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.Helper;

public class ValidationHelper
{  
    public static void ModelValidation(object obj) {
        // Model Validations
        ValidationContext validationContext = new(obj);
        List<ValidationResult> validationResults = [];
        bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
        if (!isValid)
        {
            throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
        }
    }
    
}