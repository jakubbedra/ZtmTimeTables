using ZtmTimeTables.Entity;

namespace ZtmTimeTables.Dto.Arrival;

public class GetVehicleArrivalsResponse
{
    public List<GetVehicleArrivalResponse> Arrivals { get; set; }

    public static GetVehicleArrivalsResponse EntityToDto(List<ZtmVehicleArrival> entities)
    {
        List<GetVehicleArrivalResponse> dtos = new List<GetVehicleArrivalResponse>();
        entities.ForEach(e => dtos.Add(GetVehicleArrivalResponse.EntityToDto(e)));
        return new GetVehicleArrivalsResponse() { Arrivals = dtos };
    }
    
}