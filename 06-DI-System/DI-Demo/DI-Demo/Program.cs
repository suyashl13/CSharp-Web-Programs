using ClassLibrary;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Add(
    new ServiceDescriptor( 

    );
var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.Run();
