using WebApi.Core.Services.Mapper;

namespace WebApi.User.Service.Mappers;

class UserMappers :
    IMap<Request.Register, Models.User>
{
    public Models.User Map(Request.Register model)
    {
        return new(model.Email, model.Password, model.Name, model.Surname);
    }
}
