using WebApi.Book.ResponseModels;
using WebApi.Book.RequestModels;

namespace WebApi.Book.Service;

public interface IBookService
{
    Task<IEnumerable<BookResponseModel>> GetBooks();
    Task<BookResponseModel> GetBook(int id);
    Task Post(BookRequestModel model);
    Task Put(BookRequestModel model, int id);
    Task Delete(int id);
}