using ZtmTimeTables.Entity;

namespace ZtmTimeTables.Dto.Stop;

public class GetStopsResponse
{
    public List<GetStopResponse> Stops { get; set; }

    public static GetStopsResponse EntityToDto(List<ZtmStop> entities)
    {
        List<GetStopResponse> dtos = new List<GetStopResponse>();
        entities.ForEach(e => dtos.Add(GetStopResponse.EntityToDto(e)));
        return new GetStopsResponse() { Stops = dtos };
    }
    
}