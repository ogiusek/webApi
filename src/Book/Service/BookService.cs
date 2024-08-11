using Microsoft.EntityFrameworkCore;
using WebApi.Book.ResponseModels;
using WebApi.Book.RequestModels;
using WebApi.Core.Services.Mapper;
using WebApi.Core.Attributes;

namespace WebApi.Book.Service;

[Service<IBookService>]
public class BookService : IBookService
{
    private readonly IMapper _mapper;
    private readonly BookContext _dbContext;

    public BookService(IMapper mapper, BookContext dbContext) => (_mapper, _dbContext) = (mapper, dbContext);

    public async Task<IEnumerable<BookResponseModel>> GetBooks()
    {
        // return default;
        var entities = await _dbContext.Book.ToListAsync();
        var books = entities.Select(_mapper.Map<Entities.Book, BookResponseModel>);
        return books;
    }

    public async Task<BookResponseModel> GetBook(int id)
    {
        // return default;
        var entitys = _dbContext.Book.Where(x => x.Id == id);
        if (await entitys.CountAsync() == 0)
            return null;
        var book = _mapper.Map<Entities.Book, BookResponseModel>(await entitys.FirstAsync());
        return book;
    }

    public async Task Post(BookRequestModel model)
    {
        var book = _mapper.Map<BookRequestModel, Entities.Book>(model);
        await _dbContext.Book.AddAsync(book);
        await _dbContext.SaveChangesAsync();
    }


    public async Task Put(BookRequestModel model, int id)
    {
        var book = _mapper.Map<BookRequestModel, Entities.Book>(model);
        _dbContext.Book.Update(book.SetId(id));
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var book = await _dbContext.Book.FirstOrDefaultAsync(x => x.Id == id);
        _dbContext.Book.Remove(book);
        await _dbContext.SaveChangesAsync();
    }
}