using ZtmTimeTables.Data;
using ZtmTimeTables.Entity;

namespace ZtmTimeTables.Repository;

public class UserStopRepository
{
    private readonly ApplicationDbContext _context;

    public UserStopRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<UserStop> FindAllByUser(User user) =>
        _context.UserStops
            .Where(s => s.User.Id == user.Id)
            .ToList();

    public void Save(UserStop stop)
    {
        _context.UserStops.Add(stop);
        _context.SaveChanges();
    }

    public void Remove(UserStop stop)
    {
        _context.UserStops.Remove(stop);
        _context.SaveChanges();
    }
    
}