using Microsoft.EntityFrameworkCore;

namespace WebApi.Core.Attributes;

static class ConfigureDbContextClass
{
    public static void ConfigureDbContext<TDbContext>(this WebApplicationBuilder builder)
        where TDbContext : DbContext
    {
        var connectionString = builder.Configuration.GetConnectionString("postgre");
        builder.Services.AddDbContext<TDbContext>(options => options.UseNpgsql(connectionString));

        DbContext dbContext = Activator.CreateInstance<TDbContext>()!;
        dbContext.Database.EnsureCreated();
    }
}