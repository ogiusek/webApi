namespace WebApi.User.Service.Request;

public class Register
{
    public string Email { get; set; }
    public string Password { get; set; }

    public string Name { get; set; }
    public string Surname { get; set; }
}