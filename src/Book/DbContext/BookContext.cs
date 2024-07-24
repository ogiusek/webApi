using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApi.Core.Attributes;

namespace WebApi.Book;

[UseDbContext]
public class BookContext : DbContext
{
    public DbSet<Entities.Book> Book { get; set; }

    public BookContext(DbContextOptions<BookContext> options) : base(options) { }
}
