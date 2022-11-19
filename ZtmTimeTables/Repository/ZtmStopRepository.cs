using Microsoft.EntityFrameworkCore;
using ZtmTimeTables.Data;
using ZtmTimeTables.Entity;

namespace ZtmTimeTables.Repository;

public class ZtmStopRepository
{
    private readonly ApplicationDbContext _context;

    public ZtmStopRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public ZtmStop? FindById(int id) =>
        _context.ZtmStops
            .Include(s => s.VehicleArrivals)
            .First(s => s.Id == id);

    public List<ZtmStop> FindAll() =>
        _context.ZtmStops
            .Include(s => s.VehicleArrivals)
            .ToList();

    public void Save(ZtmStop ztmStop)
    {
        _context.ZtmStops.Add(ztmStop);
        _context.SaveChanges();
    }

    public void Update(ZtmStop ztmStop)
    {
        _context.ZtmStops.Update(ztmStop);
        _context.SaveChanges();
    }

    public void Delete(ZtmStop ztmStop)
    {
        _context.ZtmStops.Remove(ztmStop);
        _context.SaveChanges();
    }
    
}