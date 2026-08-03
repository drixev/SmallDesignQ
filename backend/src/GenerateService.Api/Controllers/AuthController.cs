using GenerateService.Infraestructure.Security.Authentication;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{

    private readonly IJwtService _jwtService;
    public AuthController(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthRequest request)
    {

        if (!request.PassWord.Equals("FakeAdmin"))
        {
            return Unauthorized("Credencials invalid");
        }

        var token = _jwtService.GenerateToken(request.UserName);
        return Ok(new
        {
            token
        });
    }
}