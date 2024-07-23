using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApi.Book.Entities;

public class Book
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    protected Book() { }
    public Book(int id, string name) => (Id, Name) = (id, name);
    public Book(string name) => Name = name;

    public Book SetId(int id) => new(id, Name);
    public Book SetName(string name) => new(Id, name);
}

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(u => u.Id);

        // builder.HasMany(u => u.Roles)
        //     .WithOne()
        //     .HasForeignKey(r => r.Id)
        //     .OnDelete(DeleteBehavior.Restrict);
    }
}