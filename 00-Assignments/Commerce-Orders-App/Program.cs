public static class Program
{
    public static List<Order> orders = [];
    public static List<Product> products = [];

    static void Main(String[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        var app = builder.Build();

        app.MapGet("/", () => "The Commerce Orders App...");
        app.UseRouting();
        app.MapControllers();

        app.Run();
    }
}