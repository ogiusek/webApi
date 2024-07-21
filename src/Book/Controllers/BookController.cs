using Microsoft.AspNetCore.Mvc;
using WebApi.Book.Models;
using WebApi.Book.Entities;
using WebApi.Core.Services.Mapper;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Book.Controller;

[Route("book")]
public class BookController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly BookContext _context;

    public BookController(IMapper mapper, BookContext context) =>
        (_mapper, _context) = (mapper, context);

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var entities = await _context.Examples.ToListAsync();
        return Ok(entities);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute(Name = "id")] int id)
    {
        var entity = await _context.Examples.Where(x => x.Id == id).FirstOrDefaultAsync();
        return Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BookModel model)
    {
        var entity = _mapper.Map<BookModel, BookEntity>(model);
        await _context.Examples.AddAsync(entity);
        await _context.SaveChangesAsync();
        return NoContent();
    }


    [HttpPut]
    public async Task<IActionResult> Put([FromBody] BookModel model)
    {
        var entity = _mapper.Map<BookModel, BookEntity>(model);
        _context.Examples.Update(entity);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
    {
        var entity = await _context.Examples.FindAsync(id);
        _context.Examples.Remove(entity);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}