using ZtmTimeTables.Entity;

namespace ZtmTimeTables.Dto.Stop;

public class GetStopResponse
{
    public int? StopId { get; set; }
    public string? StopDescription { get; set; }
    public string? ZoneName { get; set; }
    public int? ZoneId { get; set; }
    public int? OnDemand { get; set; }
    
    public static GetStopResponse EntityToDto(ZtmStop entity)
    {
        return new GetStopResponse()
        {
            StopId = entity.StopId,
            StopDescription = entity.StopDesc,
            ZoneName = entity.ZoneName,
            ZoneId = entity.ZoneId,
            OnDemand = entity.OnDemand
        };
    }
    
}