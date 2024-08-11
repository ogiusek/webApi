namespace WebApi.User.Service;

public interface IUserService
{
    public Task<Response.Login> Login(Request.Login model);
    public Task<Response.Register> Register(Request.Register model);
}