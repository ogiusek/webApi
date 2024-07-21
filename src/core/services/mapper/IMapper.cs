namespace WebApi.Core.Services.Mapper;

public interface IMapper {
    TTo? Map<TFrom, TTo>(TFrom from) where TTo : class where TFrom : class;
};

// <summary>
//  !IMPORTANT!
//  using this interface can destroy the mapper
//  this interface should only be used by IMap interface
// </summary>
public interface IMapBase {};

public interface IMap<TFrom, TTo> : IMapBase {
    TTo Map(TFrom from);
}