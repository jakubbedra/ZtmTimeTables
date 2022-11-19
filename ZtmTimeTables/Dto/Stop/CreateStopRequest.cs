using ZtmTimeTables.Entity;

namespace ZtmTimeTables.Dto.Stop;

public class CreateStopRequest
{
    private string Location { get; set; }

    public static ZtmStop DtoToEntity(CreateStopRequest request)
    {
        return new ZtmStop()
        {
            Location = request.Location,
            VehicleArrivals = new List<ZtmVehicleArrival>()
        };
    }
}
