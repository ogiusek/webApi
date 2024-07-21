namespace WebApi.ExampleApi.Mappers;

using WebApi.ExampleApi.Models;
using WebApi.Global.Services.Mapper;

// examples(not used) 
class MapperOne : IMap<HelloWorldBody, HelloWorldQuery> {
    public HelloWorldQuery Map(HelloWorldBody from) {
        return new HelloWorldQuery {
            Id = from.Id,
            Name = from.Name
        };
    }
}

class MapperTwo : IMap<HelloWorldQuery, HelloWorldBody> {
    public HelloWorldBody Map(HelloWorldQuery from) {
        return new HelloWorldBody {
            Id = from.Id,
            Name = from.Name
        };
    }
}