using Microsoft.EntityFrameworkCore;
using WebApi.Core.Services.Hasher;
using WebApi.Core.Services.Mapper;

namespace WebApi.User.Service;

[Core.Attributes.Service<IUserService>]
public class UserService : IUserService
{
    private IMapper _mapper;
    private UserContext _userContext;
    private IHasher _hasher;

    public UserService(IMapper mapper, UserContext userContext, IHasher hasher) =>
        (_mapper, _userContext, _hasher) = (mapper, userContext, hasher);

    public async Task<Response.Login> Login(Request.Login request)
    {
        request.Password = _hasher.Hash(request.Password);
        var users = _userContext.Users.Where(x => x.Email == request.Email && x.PasswordHash == request.Password);
        if (await users.CountAsync() == 0)
            return null;
        // var token = ;
        return default;
    }
    public async Task<Response.Register> Register(Request.Register request)
    {
        var users = _userContext.Users.Where(x => x.Email == request.Email);
        if (await users.CountAsync() == 1) return null;
        request.Password = _hasher.Hash(request.Password);
        var user = _mapper.Map<Request.Register, Models.User>(request);
        await _userContext.Users.AddAsync(user);
        await _userContext.SaveChangesAsync();
        return new();
    }
}