using Microsoft.EntityFrameworkCore;
using ZtmTimeTables.Data;
using ZtmTimeTables.Entity;

namespace ZtmTimeTables.Repository;

public class ZtmVehicleArrivalRepository
{
    private readonly ApplicationDbContext _context;

    public ZtmVehicleArrivalRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public ZtmVehicleArrival? FindById(int id) =>
        _context.ZtmVehicleArrivals
            .Include(a => a.Vehicle)
            .Include(a => a.ZtmStop)
            .First(a => a.Id == id);

    public List<ZtmVehicleArrival> FindAll() =>
        _context.ZtmVehicleArrivals
            .Include(a => a.Vehicle)
            .Include(a => a.ZtmStop)
            .ToList();
    
    public List<ZtmVehicleArrival> FindByVehicle(ZtmVehicle ztmVehicle) =>
        _context.ZtmVehicleArrivals
            .Include(a => a.Vehicle)
            .Include(a => a.ZtmStop)
            .Where(a => a.Vehicle != null && a.Vehicle.Equals(ztmVehicle))
            .ToList();

    public List<ZtmVehicleArrival> FindByStop(ZtmStop ztmStop) =>
        _context.ZtmVehicleArrivals
            .Include(a => a.Vehicle)
            .Include(a => a.ZtmStop)
            .Where(a => a.ZtmStop != null && a.ZtmStop.Equals(ztmStop))
            .ToList();
    
    public List<ZtmVehicleArrival> FindByStopAndVehicle(ZtmStop ztmStop, ZtmVehicle ztmVehicle) =>
        _context.ZtmVehicleArrivals
            .Include(a => a.Vehicle)
            .Include(a => a.ZtmStop)
            .Where(a => a.ZtmStop != null && a.ZtmStop.Equals(ztmStop))
            .Where(a => a.Vehicle != null && a.Vehicle.Equals(ztmVehicle))
            .ToList();

    public void Save(ZtmVehicleArrival arrival)
    {
        _context.ZtmVehicleArrivals.Add(arrival);
        _context.SaveChanges();
    }

    public void Update(ZtmVehicleArrival arrival)
    {
        _context.ZtmVehicleArrivals.Update(arrival);
        _context.SaveChanges();
    }

    public void Delete(ZtmVehicleArrival arrival)
    {
        _context.ZtmVehicleArrivals.Remove(arrival);
        _context.SaveChanges();
    }

}