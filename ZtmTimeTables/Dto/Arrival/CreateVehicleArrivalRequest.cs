namespace ZtmTimeTables.Dto.Arrival;

public class CreateVehicleArrivalRequest
{
    public int VehicleId { get; set; }
    public int ZtmStopId { get; set; }
    public DateTime ArrivalTime { get; set; }
}