using System.Reflection;

namespace WebApi.Core.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class UseDbContext : Attribute { }

static class UseDbContextLoader
{
    public static void AddDbContexts(this IServiceCollection services, string connectionString)
    {
        Console.WriteLine("Loading DbContexts");
        List<Type> dbContexts = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetCustomAttribute<UseDbContext>() != null)
            .ToList();
        dbContexts.ForEach(dbContext => services.ConfigureDbContext(dbContext, connectionString));
    }
}