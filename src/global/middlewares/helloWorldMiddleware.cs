namespace WebApi.Global.Middlewares;
// NOT USED
using Microsoft.AspNetCore.Http;
using WebApi.Global.Attributes;

// [Middleware]
class HelloWorldMiddleware
{
    private readonly RequestDelegate _next;

    public HelloWorldMiddleware(RequestDelegate next) =>
        (_next) = (next);

    public async Task InvokeAsync(HttpContext context /* di */)
    {
        Console.WriteLine("Hello Middleware World");
        await _next(context);
    }
}