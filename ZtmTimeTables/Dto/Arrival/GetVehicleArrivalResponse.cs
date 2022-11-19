using ZtmTimeTables.Entity;

namespace ZtmTimeTables.Dto.Arrival;

public class GetVehicleArrivalResponse
{
    private int Id { get; set; }
    private int VehicleId { get; set; }
    private int StopId { get; set; }
    private DateTime ArrivalTime { get; set; }

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