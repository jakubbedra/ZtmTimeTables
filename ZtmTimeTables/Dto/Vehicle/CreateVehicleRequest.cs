using ZtmTimeTables.Entity;

namespace ZtmTimeTables.Dto;

public class CreateVehicleRequest
{
    public string Name { get; set; }
    public string Type { get; set; }

    public static ZtmVehicle DtoToEntityMapper(CreateVehicleRequest request)
    {
        return new ZtmVehicle()
        {
            Name = request.Name,
            Type = request.Type,
            Arrivals = new List<ZtmVehicleArrival>()
        };
    }
}