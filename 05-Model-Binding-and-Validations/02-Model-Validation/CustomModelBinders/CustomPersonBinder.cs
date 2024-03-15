using Microsoft.AspNetCore.Mvc.ModelBinding;

class CustomPersonBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        String? firstName, lastName; 
        Person person = new();
        if (bindingContext.ValueProvider.GetValue("FirstName").Count() > 0) 
        {
            firstName = bindingContext.ValueProvider.GetValue("FirstName").First();
            person.Name = firstName + " ";
        } else if (bindingContext.ValueProvider.GetValue("LastName").Count() > 0)  {
            lastName = bindingContext.ValueProvider.GetValue("LastName").First();
            person.Name += lastName;
        } 

        bindingContext.Result = ModelBindingResult.Success(person);
        return Task.CompletedTask;
    }
}