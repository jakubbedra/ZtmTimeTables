namespace ZtmTimeTables.Dto.User;

public class GetUserResponse
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public static GetUserResponse EntityToDto(Entity.User user)
    {
        return new GetUserResponse()
        {
            Id = user.Id,
            Username = user.Username,
            Password = user.Password
        };
    }
}