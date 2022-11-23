using ZtmTimeTables.Entity;

namespace ZtmTimeTables.Dto.Arrival;

public class GetArrivalResponse
{
    public string Id { get; set; }
    public string Headsign { get; set; }
    public string TheoreticalTime { get; set; }
    public string EstimatedTime { get; set; }

    public static GetArrivalResponse EntityToDto(ZtmArrival arrival)
    {
        return new GetArrivalResponse()
        {
            Id = arrival.Id,
            Headsign = arrival.Headsign,
            TheoreticalTime = arrival.TheoreticalTime,
            EstimatedTime = arrival.EstimatedTime
        };
    }
}