namespace WebApi.Core.Attributes;

using System.Reflection;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class Middleware : Attribute{}

static class MiddleWareLoader{
    public static void AddMiddlewares(this WebApplication app){
        Console.WriteLine("Loading middlewares");
        List<Type> middlewares = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetCustomAttribute<Middleware>() != null)
            .ToList();

        middlewares.ForEach(middleware => {
            app.UseMiddleware(middleware);
        });
    }
}