var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.Configure<ConfigModel>(builder.Configuration.GetSection("WheatherApi"));

var app = builder.Build();

if (app.Environment.IsProduction() || app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.MapControllers();

app.Run();
