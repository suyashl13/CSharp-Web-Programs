public static class ExtendedMiddleware
{
    public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app) {
        return app.UseMiddleware<MyCustomMiddleware>();
    }
}