public static class Program
{
    public static List<Person> people = [];
    public static void Main(String[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        var app = builder.Build();

        app.UseRouting();
        app.MapControllers();

        app.Run();
    }
}