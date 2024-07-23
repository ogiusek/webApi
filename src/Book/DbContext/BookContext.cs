using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace WebApi.Book;

public class BookContext : DbContext
{
    public DbSet<Entities.Book> Book { get; set; }

    public BookContext(DbContextOptions<BookContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
