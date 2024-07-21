namespace WebApi.Core.Attributes;

using Microsoft.AspNetCore.Mvc;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class Filter : Attribute{}

static class FilterLoader{
    public static void AddFilters(this MvcOptions app){
        Console.WriteLine("Loading filters");
        List<Type> filters = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetCustomAttribute<Filter>() != null)
            .ToList();

        filters.ForEach(filter => {
            app.Filters.Add(filter);
        });
    }
}