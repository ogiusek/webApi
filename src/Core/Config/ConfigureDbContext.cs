using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Core.Attributes;

static class ConfigureDbContextClass
{
    public static void ConfigureDbContext(this IServiceCollection services, Type DbContextType, string connectionString)
    {
        MethodInfo method = typeof(ConfigureDbContextClass).GetMethod(
            nameof(ConfigureDbContext),
            1,
            [typeof(IServiceCollection), typeof(string)] // new Type[] { typeof(IServiceCollection) }
        );
        MethodInfo generic = method!.MakeGenericMethod(DbContextType);
        generic.Invoke(null, [services, connectionString]); // generic.Invoke(null, new object[] { services, connectionString });
    }

    public static void ConfigureDbContext<TDbContext>(this IServiceCollection services, string connectionString)
        where TDbContext : DbContext
    {
        // services.AddDbContext<TDbContext>();
        services.AddDbContext<TDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
            options.UseLoggerFactory(LoggerFactory.Create(builder => builder
                .AddFilter((category, level) => level == LogLevel.Information)));
            // .AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)));
        });

        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<TDbContext>();
            context.Database.EnsureCreated();
        }

        // DbContext dbContext = Activator.CreateInstance<TDbContext>([])!;
        // DbContext dbContext = (DbContext)Activator.CreateInstance(typeof(TDbContext), [new DbContextOptions<TDbContext>()]);
        // dbContext.Database.EnsureCreated();
    }
}