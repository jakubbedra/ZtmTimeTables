using ZtmTimeTables.Data;
using ZtmTimeTables.Entity;

namespace ZtmTimeTables.Repository;

public class UserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public User? FindById(int id) =>
        _context.Users
            //.Include(s => s.VehicleArrivals)
            .FirstOrDefault(s => s.Id == id);

    public User? FindByUsername(string username) =>
        _context.Users
            //.Include(s => s.VehicleArrivals)
            .FirstOrDefault(s => s.Username.Equals(username));

    public List<User> FindAll() =>
        _context.Users
            //.Include(s => s.VehicleArrivals)
            .ToList();

    public void Save(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void Delete(User user)
    {
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

}