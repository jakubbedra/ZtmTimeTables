using ZtmTimeTables.Data;

namespace ZtmTimeTables.Repository;

public class UserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
}