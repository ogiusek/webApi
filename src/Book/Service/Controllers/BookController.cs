using Microsoft.AspNetCore.Mvc;
using WebApi.Book.RequestModels;

namespace WebApi.Book.Service.Controller;

[Route("book")]
public class BookController : ControllerBase
{
    private IBookService _bookService;
    public BookController(IBookService bookService) => _bookService = bookService;

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var books = await _bookService.GetBooks();
        return Ok(books);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute(Name = "id")] int id)
    {
        var book = await _bookService.GetBook(id);
        return book == null ? NotFound() : Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BookRequestModel requestModel)
    {
        await _bookService.Post(requestModel);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put([FromBody] BookRequestModel requestModel, [FromRoute(Name = "id")] int id)
    {
        await _bookService.Put(requestModel, id);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
    {
        await _bookService.Delete(id);
        return NoContent();
    }
}