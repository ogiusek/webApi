using Microsoft.EntityFrameworkCore;
using WebApi.Core.Attributes;

namespace WebApi.User;

[UseDbContext]
public class UserContext : DbContext
{
    public DbSet<Models.User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("account");
        modelBuilder.ApplyConfiguration(new Models.UserConfig());
    }

    public UserContext(DbContextOptions<UserContext> options) : base(options) { }
}
// dotnet ef migrations add InitialCreate -c UserContext
// dotnet ef database update -c FirstContext // this line runs automatically
