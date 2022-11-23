namespace ZtmTimeTables.Dto.User;

public class CreateUserRequest
{
    public string Username { get; set; }
    public string Password { get; set; }

    public static Entity.User DtoToEntity(CreateUserRequest request)
    {
        return new Entity.User()
        {
            Username = request.Username,
            Password = request.Password,
            Role = "User"
        };
    }
}