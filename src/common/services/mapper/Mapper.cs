namespace WebApi.Common.Services.Mapper;

using WebApi.Common.Attributes;
using System.Reflection;

[Service<IMapper>]
public class Mapper : IMapper{
    private readonly IEnumerable<IMapBase> _maps;

    public Mapper(){
        _maps = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces().Where(i => i.GetInterfaces().Where(i => i == typeof(IMapBase)).Count() != 0).Count() != 0)
            .Select(t => (IMapBase)Activator.CreateInstance(t)!);
    }

    public TTo? Map<TFrom, TTo>(TFrom from) where TTo : class where TFrom : class {
        IEnumerable<IMap<TFrom, TTo>> maps = _maps
            .Where(m => m is IMap<TFrom, TTo>)
            .Select(m => (IMap<TFrom, TTo>)m);
        if(maps.Count() == 0) return null;
        return maps.First().Map(from);
    }
}