namespace ZtmTimeTables.Entity;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public virtual ICollection<ZtmStop>? BookmarkedStops { get; set; }
}