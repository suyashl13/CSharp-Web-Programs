var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months", typeof MonthC);
} );
var app = builder.Build();


app.MapGet("/", () => "Hello World!");


// Use Endpoints
app.UseRouting();

app.UseEndpoints(async (endpoints) =>
{
    endpoints.Map("files/{filename}.{extention}", async (HttpContext context) => {
        (String fileName, String extention) = (
            Convert.ToString(context.Request.RouteValues["filename"])!,
            Convert.ToString(context.Request.RouteValues["extention"])!
        );
        HttpResponse response = context.Response;
        await response.WriteAsync($"Files / {fileName}.{extention}");
    });
});


app.UseEndpoints((endpoints) =>
{
    endpoints.Map("api/employee/{EmployeeId=Suyash}", async (HttpContext context) =>
    {
        HttpResponse response = context.Response;
        string employeeId = Convert.ToString(context.Request.RouteValues["employeeid"])!;
        await response.WriteAsync($"Employee / {employeeId}");
    });
});

app.UseEndpoints(
    async (endpoints) =>
    {
    endpoints.Map("/api/product/{id:int?}", async (HttpContext context) => {
        int? productId = Convert.ToInt32(context.Request.RouteValues["id"]);
        if (productId != null) await context.Response.WriteAsync($"Product #{productId}");
        else await context.Response.WriteAsync(" ");
    });

    endpoints.Map("/api/profile/{id:guid}", async (HttpContext context) => {
        Guid guid;
        bool isValidGuid = Guid.TryParse(Convert.ToString(context.Request.RouteValues["id"])!, out guid);

        if (isValidGuid) await context.Response.WriteAsync($"Person / {guid.ToString()}");
    });
    endpoints.Map("/api/sales/{year:int:min(1900):max(2300)}", async (HttpContext context) => {
        HttpResponse response = context.Response;

        int year = Convert.ToInt16(context.Request.RouteValues["year"]);

        await response.WriteAsync($"Year : {year}");
    });
    }
);

app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("Request recieved!");
});
app.Run();

