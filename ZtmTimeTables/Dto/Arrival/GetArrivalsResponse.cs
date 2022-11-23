using ZtmTimeTables.Entity;

namespace ZtmTimeTables.Dto.Arrival;

public class GetArrivalsResponse
{
    public string LastUpadate { get; set; }
    public List<GetArrivalResponse> arrivals { get; set; }

    public static GetArrivalsResponse EntityToDto(ZtmArrivalsCollection entity)
    {
        List<GetArrivalResponse> dtos = new List<GetArrivalResponse>();
        entity.Delay.ForEach(e => dtos.Add(GetArrivalResponse.EntityToDto(e)));
        return new GetArrivalsResponse()
        {
            LastUpadate = entity.LastUpdate,
            arrivals = dtos
        };
    }

}