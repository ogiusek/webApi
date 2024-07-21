namespace WebApi.Global.Middlewares;
// NOT USED
// using Microsoft.AspNetCore.Mvc;
// using FluentValidation;
// to use use 
// [MiddlewareFilter(typeof(ValidationPipeline<HelloWorldQueryModel, FromBodyAttribute>))]
// [MiddlewareFilter(typeof(ValidationPipeline))]

// public class ValidationMiddleware<TModel, TValidator, TFrom>
//     where TModel : class
//     where TValidator : AbstractValidator<TModel>
//     where TFrom : Attribute
// {
//     private readonly RequestDelegate _next;

//     public ValidationMiddleware(RequestDelegate next) =>
//         (_next) = (next);

//     public async Task InvokeAsync(HttpContext context, TModel model, TValidator validator)
//     {
//         // context.Request.Query.ToObject<TModel>();

//         Console.WriteLine("Hello Middleware World");
//         await _next(context);
//     }
// }

// public class ValidationPipeline<TModel>
//     where TModel : class
// {
//     public static void Configure(IApplicationBuilder applicationBuilder)
//     {
//         ValidationPipeline<TModel, FromBodyAttribute>.Configure(applicationBuilder);
//     }
// }

// public class ValidationPipeline<TModel, TFrom>
//     where TModel : class
//     where TFrom : Attribute 
// {
//     public static void Configure(IApplicationBuilder applicationBuilder)
//     {
//         applicationBuilder.UseMiddleware<HelloWorldMiddleware>();
//     }
// }

// public class ValidationPipeline
// {
//     public static void Configure(IApplicationBuilder applicationBuilder)
//     {
//     }
// }