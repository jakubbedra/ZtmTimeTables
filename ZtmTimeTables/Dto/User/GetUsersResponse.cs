namespace ZtmTimeTables.Dto.User;

public class GetUsersResponse
{
    public List<GetUserResponse> Users { get; set; }

    public static GetUsersResponse EntityToDto(List<Entity.User> users)
    {
        List<GetUserResponse> dtos = new List<GetUserResponse>();
        users.ForEach(u => dtos.Add(GetUserResponse.EntityToDto(u)));
        return new GetUsersResponse() { Users = dtos };
    }
}