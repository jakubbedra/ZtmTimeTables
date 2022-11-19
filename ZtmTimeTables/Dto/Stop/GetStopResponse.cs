using ZtmTimeTables.Entity;

namespace ZtmTimeTables.Dto.Stop;

public class GetStopResponse
{
    public int Id { get; set; }
    public string Location { get; set; }

    public static GetStopResponse EntityToDto(ZtmStop entity)
    {
        return new GetStopResponse()
        {
            Id = entity.Id,
            Location = entity.Location
        };
    }
}