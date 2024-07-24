using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApi.Core.Attributes;

namespace WebApi.Book;

[UseDbContext]
public class BookContext : DbContext
{
    public DbSet<Entities.Book> Book { get; set; }

    public BookContext(DbContextOptions<BookContext> options) : base(options) { }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    // }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     // var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
    //     // optionsBuilder.UseNpgsql(connectionString);
    // }
}
