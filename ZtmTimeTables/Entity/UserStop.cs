namespace ZtmTimeTables.Entity;

public class UserStop
{
    public int Id { get; set; }
    public User User { get; set; }
    public int StopId { get; set; }
}