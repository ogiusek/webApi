using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WebApi.Core.Attributes;

static class ConfigureDbContextClass
{
    public static void ConfigureDbContext(this IServiceCollection services, Type DbContextType, string connectionString)
    {
        MethodInfo method = typeof(ConfigureDbContextClass).GetMethod(
            nameof(ConfigureDbContext),
            1,
            [typeof(IServiceCollection), typeof(string)]
        );
        MethodInfo generic = method!.MakeGenericMethod(DbContextType);
        generic.Invoke(null, [services, connectionString]);
    }

    public static void ConfigureDbContext<TDbContext>(this IServiceCollection services, string connectionString)
        where TDbContext : DbContext
    {
        services.AddDbContext<TDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
            options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddFilter((category, level) => level == LogLevel.Information)));
        });

        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<TDbContext>();
            context.Database.Migrate();
        }
    }
}

