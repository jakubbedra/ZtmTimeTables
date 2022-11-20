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
    private readonly ZtmVehicleArrivalService _ztmVehicleArrivalService;

    public ZtmStopController(
        ZtmStopService ztmStopService,
        ZtmVehicleArrivalService ztmVehicleArrivalService
    )
    {
        _ztmStopService = ztmStopService;
        _ztmVehicleArrivalService = ztmVehicleArrivalService;
    }

    [HttpGet]
    [Route("/api/stops")]
    public JsonResult GetStops()
    {
        return new JsonResult(GetStopsResponse.EntityToDto(_ztmStopService.FindAll()));
    }

    [HttpGet]
    [Route("/api/stops/{id}")]
    public JsonResult GetStop(int id)
    {
        ZtmStop? stop = _ztmStopService.FindById(id);
        if (stop == null)
        {
            return new JsonResult(NotFound());
        }

        return new JsonResult(GetStopResponse.EntityToDto(stop));
    }

    [HttpPost]
    [Route("/api/stops")]
    public JsonResult CreateVehicle(CreateStopRequest request)
    {
        ZtmStop stop = CreateStopRequest.DtoToEntity(request);
        _ztmStopService.AddZtmStop(stop);
        return new JsonResult(Accepted());
    }

    [HttpPut]
    [Route("/api/stops/{id}")]
    public JsonResult UpdateStop(int id, UpdateStopRequest request)
    {
        ZtmStop? stop = _ztmStopService.FindById(id);
        if (stop == null)
        {
            return new JsonResult(NotFound());
        }

        stop.Location = request.Location;
        _ztmStopService.Update(stop);

        return new JsonResult(Accepted());
    }

    [HttpDelete]
    [Route("/api/stops/{id}")]
    public JsonResult DeleteStop(int id)
    {
        ZtmStop? stop = _ztmStopService.FindById(id);
        if (stop == null)
        {
            return new JsonResult(NotFound());
        }

        _ztmStopService.Delete(stop);
        return new JsonResult(Ok());
    }

    [HttpGet]
    [Route("/api/stops/{id}/arrivals")]
    public JsonResult GetArrivals(int id)
    {
        ZtmStop? stop = _ztmStopService.FindById(id);
        if (stop == null)
        {
            return new JsonResult(NotFound());
        }

        List<ZtmVehicleArrival> arrivals = _ztmVehicleArrivalService.FindByStop(stop);
        return new JsonResult(GetVehicleArrivalsResponse.EntityToDto(arrivals));
    }
}