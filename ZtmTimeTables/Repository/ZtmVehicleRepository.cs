using Microsoft.EntityFrameworkCore;
using ZtmTimeTables.Data;
using ZtmTimeTables.Entity;

namespace ZtmTimeTables.Repository;

public class ZtmVehicleRepository
{
    private readonly ApplicationDbContext _context;

    public ZtmVehicleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public ZtmVehicle? FindById(int id) => 
        _context.ZtmVehicles
            .Include(v => v.Arrivals)!
            .ThenInclude(a => a.ZtmStop)
            .First(v => v.Id == id);

    public List<ZtmVehicle> FindAll() =>
        _context.ZtmVehicles
            .Include(v => v.Arrivals)!
            .ThenInclude(a => a.ZtmStop)
            .ToList();

    public void Save(ZtmVehicle vehicle)
    {
        _context.ZtmVehicles.Add(vehicle);
        _context.SaveChanges();
    }

    public void Update(ZtmVehicle vehicle)
    {
        _context.ZtmVehicles.Update(vehicle);
        _context.SaveChanges();
    }

    public void Delete(ZtmVehicle vehicle)
    {
        _context.ZtmVehicles.Remove(vehicle);
        _context.SaveChanges();
    }
}