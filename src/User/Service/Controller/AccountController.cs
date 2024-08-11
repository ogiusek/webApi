using Microsoft.AspNetCore.Mvc;

namespace WebApi.User.Service.Controller;

[Route("account")]
public class AccountController : ControllerBase
{
    private IUserService _userService;
    public AccountController(IUserService userService) => _userService = userService;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Request.Login request)
    {
        var response = await _userService.Login(request);
        if (response == null)
            return NotFound();
        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] Request.Register request)
    {
        var response = await _userService.Register(request);
        if (response == null)
            return Conflict();
        return Ok(response);
    }
}