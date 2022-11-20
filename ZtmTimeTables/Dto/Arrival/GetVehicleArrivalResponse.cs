using ZtmTimeTables.Entity;

namespace ZtmTimeTables.Dto.Arrival;

public class GetVehicleArrivalResponse
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public int StopId { get; set; }
    public DateTime ArrivalTime { get; set; }

    public static GetVehicleArrivalResponse EntityToDto(ZtmVehicleArrival entity)
    {
        return new GetVehicleArrivalResponse()
        {
            Id = entity.Id,
            VehicleId = entity.Vehicle.Id,
            StopId = entity.ZtmStop.Id,
            ArrivalTime = entity.ArrivalTime
        };
    }
    
}