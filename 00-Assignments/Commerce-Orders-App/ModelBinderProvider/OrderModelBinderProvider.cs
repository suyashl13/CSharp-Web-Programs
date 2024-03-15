using Microsoft.AspNetCore.Mvc.ModelBinding;

class OrderModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        throw new NotImplementedException();
    }
}