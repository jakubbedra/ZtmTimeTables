namespace ZtmTimeTables.Entity;

public class ZtmStop
{
    public int Id { get; set; }
    public string Location { get; set; }
    public virtual ICollection<ZtmVehicleArrival> VehicleArrivals { get; set; }
}