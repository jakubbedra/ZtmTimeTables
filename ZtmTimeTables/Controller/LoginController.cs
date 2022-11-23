using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ZtmTimeTables.Dto.User;
using ZtmTimeTables.Entity;
using ZtmTimeTables.Service;

namespace ZtmTimeTables.Controller;

[ApiController]
public class LoginController : ControllerBase
{
    private readonly UserService _userService;

    public LoginController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("/api/login")]
    [AllowAnonymous]
    public JsonResult Login(LoginRequest request)
    {
        var user = Authenticate(request);
        if (user == null)
        {
            return new JsonResult(NotFound());
        }

        var token = Generate(user);
        return new JsonResult(token);
    }

    private string Generate(User user)
    {
        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("DhftOS5uphK3vmCJQrexST1RsyjZBjXWRgJMFPU4")
        );
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var token = new JwtSecurityToken(
            "https://localhost:7146/",
            "https://localhost:7146/",
            claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private User? Authenticate(LoginRequest request)
    {
        User? current = _userService.FindByUsername(request.Username);
        if (current == null) return null;
        if (current.Password != request.Password) return null;
        //    Users.FirstOrDefault(
        //    u => u.Username == request.Username && u.Password == request.Password
        //);
        return current;
    }

    private List<User> Users = new List<User>()
    {
        new User() { Id = 1, Password = "admin", Username = "admin", Role = "Admin" },
        new User() { Id = 1, Password = "user", Username = "user", Role = "User" }
    };
}