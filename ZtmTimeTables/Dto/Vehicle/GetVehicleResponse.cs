using ZtmTimeTables.Entity;

namespace ZtmTimeTables.Dto;

public class GetVehicleResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }

    public static GetVehicleResponse EntityToDto(ZtmVehicle vehicle)
    {
        return new GetVehicleResponse()
        {
            Id = vehicle.Id,
            Name = vehicle.Name,
            Type = vehicle.Type
        };
    }
    
}