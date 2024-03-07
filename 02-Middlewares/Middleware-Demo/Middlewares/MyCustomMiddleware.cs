
public class MyCustomMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("Written in custom middleware.\n");
        next(context);
    }
}