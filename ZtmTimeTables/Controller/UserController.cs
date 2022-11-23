using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZtmTimeTables.Dto.User;
using ZtmTimeTables.Entity;
using ZtmTimeTables.Service;

namespace ZtmTimeTables.Controller;

[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("/api/users")]
    [AllowAnonymous]
    public JsonResult GetUsers()
    {
        List<User> users = _userService.FindAll();
        return new JsonResult(GetUsersResponse.EntityToDto(users));
    }
    
    [HttpPost]
    [Route("/api/users")]
    [AllowAnonymous]
    public JsonResult CreateUser(CreateUserRequest request)
    {
        User? duplicate = _userService.FindByUsername(request.Username);
        if (duplicate != null)
        {
            return new JsonResult(HttpStatusCode.Forbidden);
        }

        User user = CreateUserRequest.DtoToEntity(request);
        _userService.AddUser(user);
        return new JsonResult(HttpStatusCode.Accepted);
    }
    
    [HttpDelete]
    [Route("/api/users/{id}")]
    [AllowAnonymous]
    public JsonResult DeleteUser(int id)
    {
        User? user = _userService.FindById(id);
        if (user == null)
        {
            return new JsonResult(HttpStatusCode.NotFound);
        }

        _userService.Delete(user);
        return new JsonResult(HttpStatusCode.Accepted);
    }
    
}