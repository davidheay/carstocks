using carstocks.models;
using carstocks.utils;
using Microsoft.AspNetCore.Mvc;

namespace carstocks.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    public readonly JwtTokenGenerator _jwtTokenGenerator;
    public AuthController(JwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    [HttpPost("generateToken")]
    public IActionResult GenerateToken([FromBody] Dealer dealer)
    {

        var token = _jwtTokenGenerator.GenerateToken(dealer.Id);

        return Ok(new { token });
    }
}