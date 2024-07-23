using WebApi.Book.ResponseModels;
using WebApi.Book.RequestModels;
using WebApi.Core.Services.Mapper;

namespace WebApi.Book.Mappers;

class BookModelToBookEntity : IMap<BookRequestModel, Entities.Book>
{
    public Entities.Book Map(BookRequestModel source)
    {
        return new Entities.Book(source.Name);
    }
}

class BookEntityToBookModel : IMap<Entities.Book, BookResponseModel>
{
    public BookResponseModel Map(Entities.Book source)
    {
        return new BookResponseModel(source.Id, source.Name);
    }
}