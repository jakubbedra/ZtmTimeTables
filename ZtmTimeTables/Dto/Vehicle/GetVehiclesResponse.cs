using ZtmTimeTables.Entity;

namespace ZtmTimeTables.Dto;

public class GetVehiclesResponse
{
    public List<GetVehicleResponse> Vehicles { get; set; }

    public static GetVehiclesResponse EntityToDto(List<ZtmVehicle> vehicles)
    {
        List<GetVehicleResponse> vehicleDtos = new List<GetVehicleResponse>();
        vehicles.ForEach(v => vehicleDtos.Add(GetVehicleResponse.EntityToDto(v)));
        return new GetVehiclesResponse() { Vehicles = vehicleDtos };
    }
    
}