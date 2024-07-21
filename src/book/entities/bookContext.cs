namespace WebApi.Book.Entities;

using Microsoft.EntityFrameworkCore;
using WebApi.Core.Attributes;

[Service]
public class BookContext : DbContext
{
    public DbSet<BookEntity> Examples { get; set; }

    public BookContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        string host =     Environment.GetEnvironmentVariable("DB_HOST")??     throw new Exception("env DB_HOST is missing");
        string database = Environment.GetEnvironmentVariable("DB_DATABASE")?? throw new Exception("env DB_DATABASE is missing");
        string username = Environment.GetEnvironmentVariable("DB_USERNAME")?? throw new Exception("env DB_USER is missing");
        string password = Environment.GetEnvironmentVariable("DB_PASSWORD")?? throw new Exception("env DB_PASSWORD is missing");
        options.UseNpgsql($"Host={host};Database={database};Username={username};Password={password}");
    }
}