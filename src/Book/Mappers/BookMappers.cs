using WebApi.Book.Entities;
using WebApi.Book.Models;
using WebApi.Core.Services.Mapper;

namespace WebApi.Book.Mappers;

class BookModelToBookEntity : IMap<BookModel, BookEntity>
{
    public BookEntity Map(BookModel source)
    {
        return new BookEntity
        {
            Id = source.Id,
            Name = source.Name
        };
    }
}