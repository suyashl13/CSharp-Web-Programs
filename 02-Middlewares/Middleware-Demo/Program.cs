var builder = WebApplication.CreateBuilder(args);

// Register in DI system.
builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();

app.MapGet("/help", () => { return "Help Section"; });
app.MapGet("/", () => "Hello World!");


// Create Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Written in middleware 1\n");
    await next(context);
    await context.Response.WriteAsync("Written in middleware 1 (In Round 2)\n");
});

// Use Custom Middleware (Extension method)
app.UseMyCustomMiddleware();


// Middleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Written in middleware 2\n");
});


app.UseWhen((context) => context.Request.Query.ContainsKey("username"), app =>
{
    app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("Written in branching middleware");
        await next(context);
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from main branch.");
});

app.Run();