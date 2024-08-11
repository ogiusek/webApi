using Microsoft.EntityFrameworkCore;
using WebApi.Core.Attributes;

namespace WebApi.Book;

[UseDbContext]
public class BookContext : DbContext
{
    public DbSet<Entities.Book> Book { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("book");
        modelBuilder.ApplyConfiguration(new Entities.BookConfiguration());
    }

    public BookContext(DbContextOptions<BookContext> options) : base(options) { }
}
