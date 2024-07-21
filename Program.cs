namespace WebApi;

// asp net core
// jwt
// identity - for external authentication

// EntityFramework
// linq (pretty much js array functions)
// xunit for testing

using Common.Attributes;

static class Program{
    public static void Main(string[] args){
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.ConfigureServices();

        var app = builder.Build();
        app.ConfigureApp();

        app.Run();
    }

    public static void ConfigureServices(this IServiceCollection services){
        services.Addservices();
        services.AddControllers(options => {
            options.AddFilters();
        });
    }

    public static void ConfigureApp(this WebApplication app){
        app.MapControllers();
        app.AddMiddlewares();

        app.UseAuthorization();
        app.UseRouting();
        // app.UseHttpsRedirection();

        if (!app.Environment.IsDevelopment())
            return;
        // development
    }
}
