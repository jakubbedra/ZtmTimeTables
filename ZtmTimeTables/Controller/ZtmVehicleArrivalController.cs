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

    [HttpGet("/api/arrivals")]
    public JsonResult GetArrivals()
    {
        return new JsonResult(GetVehicleArrivalsResponse.EntityToDto(_ztmVehicleArrivalService.FindAll()));
    }

    [HttpGet("/api/arrivals/{id}")]
    public JsonResult GetArrival(int id)
    {
        ZtmVehicleArrival? arrival = _ztmVehicleArrivalService.FindById(id);
        if (arrival == null)
        {
            return new JsonResult(NotFound());
        }

        return new JsonResult(GetVehicleArrivalResponse.EntityToDto(arrival));
    }

    [HttpPost("/api/arrivals")]
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

        return new JsonResult(Accepted());
    }

    [HttpPut("/api/arrivals/{id}")]
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

    [HttpDelete("/api/arrivals/{id}")]
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