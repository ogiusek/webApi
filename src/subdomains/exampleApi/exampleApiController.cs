namespace WebApi.ExampleApi.Controller;

using Microsoft.AspNetCore.Mvc;
using WebApi.ExampleApi.Models;
using WebApi.Common.Services.Mapper;

[Route("example_api")]
public class ExampleApiController : ControllerBase {
    private readonly IMapper _mapper;
    public ExampleApiController(IMapper mapper) => (_mapper) = (mapper);

    [HttpGet("perf")]
    public IActionResult perfTest() {
        var headers = Request.Headers;
        return Ok(headers);
    }

    [HttpGet]
    public IActionResult get(HelloWorldQuery dto) {
        HelloWorldBody body = _mapper.Map<HelloWorldQuery, HelloWorldBody>(dto)!;
        var headers = Request.Headers;
        return Ok(headers);
    }

    [HttpPost]
    public IActionResult post([FromBody]HelloWorldBody bodyDto, [FromQuery]HelloWorldQuery queryDto) {
        return Ok(new {
            body = bodyDto,
            query = queryDto
        });
    }

    [HttpGet("{id}")]
    public IActionResult getId([FromRoute(Name = "id")]int idn) {
        return Ok(idn);
    }
}