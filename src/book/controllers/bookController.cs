namespace WebApi.Book.Controller;

using Microsoft.AspNetCore.Mvc;
using WebApi.Book.Models;
using WebApi.Book.Entities;
using WebApi.Core.Services.Mapper;

[Route("book")]
public class BookController : ControllerBase {
    private readonly IMapper _mapper;
    private readonly BookContext _context;

    public BookController(IMapper mapper, BookContext context) => (_mapper, _context) = (mapper, context);
    
    [HttpGet]
    public IActionResult get() {
        return Ok(_context.Examples.ToList());
    }

    [HttpGet("{id:int}")]
    public IActionResult get([FromRoute(Name = "id")]int id) {
        var entity = _context.Examples.Find(id);
        if(entity == null) return NotFound("not found id");
        return Ok(entity);
    }

    [HttpPost]
    public IActionResult post([FromBody]BookModel model) {
        var entity = _mapper.Map<BookModel, BookEntity>(model)!;
        _context.Examples.Add(entity);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpPut("{id:int}")]
    public IActionResult put([FromRoute(Name = "id")]int id, [FromBody]BookModel model) {
        var entity = _context.Examples.Find(id);
        if(entity == null) return NotFound();
        entity.Name = model.Name!;
        _context.Examples.Update(entity);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult delete([FromRoute(Name = "id")]int id) {
        _context.Examples.Remove(_context.Examples.Find(id)!);
        _context.SaveChanges();
        return NoContent();
    }
}