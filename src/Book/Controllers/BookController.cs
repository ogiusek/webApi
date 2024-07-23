using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebApi.Book.ResponseModels;
using WebApi.Book.RequestModels;
using WebApi.Core.Services.Mapper;

namespace WebApi.Book.Controller;

[Route("book")]
public class BookController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly BookContext _dbContext;

    public BookController(IMapper mapper, BookContext dbContext) => (_mapper, _dbContext) = (mapper, dbContext);

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var entities = await _dbContext.Book.ToListAsync();
        var books = entities.Select(_mapper.Map<Entities.Book, BookResponseModel>);
        return Ok(books);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute(Name = "id")] int id)
    {
        var entity = await _dbContext.Book.FirstOrDefaultAsync(x => x.Id == id);
        var book = _mapper.Map<Entities.Book, BookResponseModel>(entity);
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BookRequestModel model)
    {
        var book = _mapper.Map<BookRequestModel, Entities.Book>(model);
        await _dbContext.Book.AddAsync(book);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put([FromBody] BookRequestModel model, [FromRoute(Name = "id")] int id)
    {
        var book = _mapper.Map<BookRequestModel, Entities.Book>(model);
        _dbContext.Book.Update(book.SetId(id));
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
    {
        var book = await _dbContext.Book.FirstOrDefaultAsync(x => x.Id == id);
        _dbContext.Book.Remove(book);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }
}