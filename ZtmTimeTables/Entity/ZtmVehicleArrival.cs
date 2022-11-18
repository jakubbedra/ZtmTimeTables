namespace ZtmTimeTables.Entity;

public class ZtmVehicleArrival
{
    public int Id { get; set; }
    public ZtmVehicle? Vehicle { get; set; }
    public ZtmStop? ZtmStop { get; set; }
    public DateTime ArrivalTime { get; set; }
}