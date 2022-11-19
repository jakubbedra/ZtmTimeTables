using System.Net;
using Microsoft.AspNetCore.Mvc;
using ZtmTimeTables.Dto;
using ZtmTimeTables.Entity;
using ZtmTimeTables.Service;

namespace ZtmTimeTables.Controller;

[ApiController]
public class ZtmVehicleController : ControllerBase
{
    private readonly ZtmVehicleService _ztmVehicleService;

    public ZtmVehicleController(ZtmVehicleService ztmVehicleService)
    {
        _ztmVehicleService = ztmVehicleService;
    }

    [HttpGet("/api/vehicles")]
    public JsonResult GetVehicles()
    {
        return new JsonResult(GetVehiclesResponse.EntityToDto(_ztmVehicleService.FindAll()));
    }

    [HttpGet]
    [Route("/api/vehicles/{id}")]
    public JsonResult GetVehicle(int id)
    {
        ZtmVehicle? vehicle = _ztmVehicleService.FindById(id);
        if (vehicle == null)
        {
            return new JsonResult(NotFound());
        }

        return new JsonResult(HttpStatusCode.OK,GetVehicleResponse.EntityToDto(vehicle));
    }

    [HttpPost]
    [Route("/api/vehicles")]
    public JsonResult CreateVehicle(CreateVehicleRequest requestDto)
    {
        ZtmVehicle vehicle = CreateVehicleRequest.DtoToEntityMapper(requestDto);
        _ztmVehicleService.AddZtmVehicle(vehicle);
        return new JsonResult(Accepted());
    }

    [HttpPut]
    [Route("/api/vehicles/{id}")]
    public JsonResult UpdateVehicle(int id, UpdateVehicleRequest requestDto)
    {
        ZtmVehicle? vehicle = _ztmVehicleService.FindById(id);
        if (vehicle == null)
        {
            return new JsonResult(NotFound());
        }

        vehicle.Name = requestDto.Name;
        vehicle.Type = requestDto.Type;

        _ztmVehicleService.Update(vehicle);
        return new JsonResult(HttpStatusCode.Accepted);
    }

    [HttpDelete]
    [Route("/api/vehicles/{id}")]
    public JsonResult DeleteVehicle(int id)
    {
        ZtmVehicle? vehicle = _ztmVehicleService.FindById(id);
        if (vehicle == null)
        {
            return new JsonResult(NotFound());
        }

        _ztmVehicleService.Delete(vehicle);
        return new JsonResult(HttpStatusCode.Accepted);
    }
}