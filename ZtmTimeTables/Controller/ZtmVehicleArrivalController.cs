using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZtmTimeTables.Dto.Arrival;
using ZtmTimeTables.Entity;
using ZtmTimeTables.Service;

namespace ZtmTimeTables.Controller;

[ApiController]
public class ZtmVehicleArrivalController : ControllerBase
{
    private readonly ZtmStopService _ztmStopService;
    private readonly ZtmVehicleService _ztmVehicleService;
    private readonly ZtmVehicleArrivalService _ztmVehicleArrivalService;

    public ZtmVehicleArrivalController(
        ZtmStopService ztmStopService,
        ZtmVehicleService ztmVehicleService,
        ZtmVehicleArrivalService ztmVehicleArrivalService
    )
    {
        _ztmStopService = ztmStopService;
        _ztmVehicleService = ztmVehicleService;
        _ztmVehicleArrivalService = ztmVehicleArrivalService;
    }

    [HttpGet]
    [Route("/api/arrivals")]
    [Authorize(Roles = "Admin")]
    public JsonResult GetArrivals()
    {
        User currentUser = GetCurrentUser();
        GetVehicleArrivalsResponse dto = GetVehicleArrivalsResponse.EntityToDto(_ztmVehicleArrivalService.FindAll());
        return new JsonResult(dto);
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
    
    
    [HttpGet]
    [Route("/api/arrivals/{id}")]
    public JsonResult GetArrival(int id)
    {
        ZtmVehicleArrival? arrival = _ztmVehicleArrivalService.FindById(id);
        if (arrival == null)
        {
            return new JsonResult(NotFound());
        }

        return new JsonResult(GetVehicleArrivalResponse.EntityToDto(arrival));
    }

    [HttpPost]
    [Route("/api/arrivals")]
    public JsonResult CreateArrival(CreateVehicleArrivalRequest request)
    {
        ZtmStop? stop = _ztmStopService.FindById(request.ZtmStopId);
        ZtmVehicle? vehicle = _ztmVehicleService.FindById(request.VehicleId);

        if (stop == null || vehicle == null)
        {
            return new JsonResult(NotFound());
        }

        ZtmVehicleArrival arrival = new ZtmVehicleArrival()
        {
            Vehicle = vehicle,
            ZtmStop = stop,
            ArrivalTime = request.ArrivalTime
        };
        _ztmVehicleArrivalService.AddArrival(arrival);

        return new JsonResult(Accepted());
    }

    [HttpPut]
    [Route("/api/arrivals/{id}")]
    public JsonResult UpdateArrival(int id, UpdateArrivalRequest request)
    {
        ZtmVehicleArrival? arrival = _ztmVehicleArrivalService.FindById(id);
        if (arrival == null)
        {
            return new JsonResult(NotFound());
        }

        arrival.ArrivalTime = request.ArrivalTime;

        return new JsonResult(Accepted());
    }

    [HttpDelete]
    [Route("/api/arrivals/{id}")]
    public JsonResult DeleteArrival(int id)
    {
        ZtmVehicleArrival? arrival = _ztmVehicleArrivalService.FindById(id);
        if (arrival == null)
        {
            return new JsonResult(NotFound());
        }

        _ztmVehicleArrivalService.Delete(arrival);
        return new JsonResult(Ok());
    }
}