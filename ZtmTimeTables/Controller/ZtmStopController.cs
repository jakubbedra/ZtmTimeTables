using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZtmTimeTables.Dto.Arrival;
using ZtmTimeTables.Dto.Stop;
using ZtmTimeTables.Entity;
using ZtmTimeTables.Service;

namespace ZtmTimeTables.Controller;

[ApiController]
public class ZtmStopController : ControllerBase
{
    private readonly ZtmStopService _ztmStopService;
    private readonly UserService _userService;
    private readonly UserStopService _userStopService;

    public ZtmStopController(
        ZtmStopService ztmStopService,
        UserService userService,
        UserStopService userStopService
    )
    {
        _ztmStopService = ztmStopService;
        _userService = userService;
        _userStopService = userStopService;
    }
    
    [HttpGet]
    [Route("/api/stops")]
    [AllowAnonymous]
    public JsonResult GetAllStops()
    {
        User currentUser = GetCurrentUser();
        if (currentUser == null)
        {
            return new JsonResult(NotFound());
        }

        int result = _ztmStopService.WriteAllToFile().Result;
        Dictionary<DateOnly, ZtmStopCollection> all = _ztmStopService.FindAll();
        List<ZtmStop> ztmStops = new List<ZtmStop>();
        foreach (var (key, value) in all)
        {
            value.Stops.ForEach(s => ztmStops.Add(s));
        }
        
        return new JsonResult(GetStopsResponse.EntityToDto(ztmStops));
    }
    
    [HttpGet]
    [Route("/api/users/current/stops")]
    [AllowAnonymous]
    public JsonResult GetAllUserStops()
    {
        User currentUser = GetCurrentUser();
        if (currentUser == null)
        {
            return new JsonResult(NotFound());
        }

        User? user = _userService.FindByUsername(currentUser.Username);

        List<UserStop> userStops = _userStopService.FindAllUserStops(user);
        List<ZtmStop> ztmStops = new List<ZtmStop>();
        
        foreach (UserStop stop in userStops)
            ztmStops.Add(_ztmStopService.FindById(stop.StopId));

        return new JsonResult(GetStopsResponse.EntityToDto(ztmStops));
    }
    
    [HttpGet]
    [Route("/api/arrivals/{stopId}")]
    [AllowAnonymous]
    public JsonResult GetUserStops(int stopId)
    {
        User currentUser = GetCurrentUser();
        if (currentUser == null)
        {
            return new JsonResult(NotFound());
        }

        ZtmArrivalsCollection result = _ztmStopService.FindArrivalsByStopId(stopId).Result;
        
        return new JsonResult(GetArrivalsResponse.EntityToDto(result));
    }

    [HttpPost]
    [Route("/api/users/current/stops")]
    [Authorize]
    public JsonResult AddStopBookmark(AddUserStopRequest request)
    {
        User currentUser = GetCurrentUser();
        if (currentUser == null)
        {
            return new JsonResult(NotFound());
        }

        UserStop stop = new UserStop()
        {
            StopId = request.StopId,
            User = _userService.FindByUsername(currentUser.Username)
        };
        
        _userStopService.AddUserStop(stop);
        return new JsonResult(Ok());
    }
    
    [HttpDelete]
    [Route("/api/users/current/stops/{stopId}")]
    [Authorize]
    public JsonResult AddStopBookmark(int stopId)
    {
        User currentUser = GetCurrentUser();
        if (currentUser == null)
        {
            return new JsonResult(NotFound());
        }

        User? user = _userService.FindByUsername(currentUser.Username);

        UserStop? stop = _userStopService.FindByStopIdAndUser(stopId, user);
        if (stop == null)
        {
            return new JsonResult(NotFound());
        }
        _userStopService.RemoveUserStop(stop);

        return new JsonResult(Ok());
    }

    private User GetCurrentUser()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;

        if (identity != null)
        {
            var userClaims = identity.Claims;

            return new User
            {
                Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
            };
        }

        return null;
    }
}