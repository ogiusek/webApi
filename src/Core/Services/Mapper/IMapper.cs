namespace WebApi.Core.Services.Mapper;

public interface IMapper
{
    TTo Map<TFrom, TTo>(TFrom from) where TTo : class where TFrom : class;
}

interface IMapBase { }

interface IMap<TFrom, TTo> : IMapBase
{
    TTo Map(TFrom from);
}