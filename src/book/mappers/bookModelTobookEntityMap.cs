namespace WebApi.Book.Mappers;

using WebApi.Book.Entities;
using WebApi.Book.Models;
using WebApi.Core.Services.Mapper;

public class BookModelToExampleBookMap : IMap<BookModel, BookEntity>
{
    public BookEntity Map(BookModel source)
    {
        return new BookEntity
        {
            Name = source.Name!
        };
    }
}