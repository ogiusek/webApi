using WebApi.Book;
using WebApi.Core.Attributes;

namespace WebApi;

// asp net core
// jwt
// identity - for external authentication

// EntityFramework
// linq (pretty much js array functions)
// xunit for testing


static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.Addservices();
        builder.Services.AddControllers(options =>
        {
            options.AddFilters();
        });

        var app = builder.Build();

        app.MapControllers();
        app.AddMiddlewares();

        app.UseAuthorization();
        app.UseRouting();

        app.Run();
    }
}
