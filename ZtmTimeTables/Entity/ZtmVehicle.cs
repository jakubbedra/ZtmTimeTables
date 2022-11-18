namespace ZtmTimeTables.Entity;

public class ZtmVehicle
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public virtual ICollection<ZtmVehicleArrival>? Arrivals { get; set; }
}