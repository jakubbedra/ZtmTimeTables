using ZtmTimeTables.Entity;
using ZtmTimeTables.Repository;

namespace ZtmTimeTables.Service;

public class ZtmVehicleService
{
    private readonly ZtmVehicleRepository _ztmVehicleRepository;

    public ZtmVehicleService(ZtmVehicleRepository ztmVehicleRepository)
    {
        _ztmVehicleRepository = ztmVehicleRepository;
    }

    public ZtmVehicle? FindById(int id)
    {
        return _ztmVehicleRepository.FindById(id);
    }

    public List<ZtmVehicle> FindAll()
    {
        return _ztmVehicleRepository.FindAll();
    }
    
    public void AddZtmVehicle(ZtmVehicle vehicle)
    {
        _ztmVehicleRepository.Save(vehicle);
    }

    public void Update(ZtmVehicle vehicle)
    {
        _ztmVehicleRepository.Update(vehicle);
    }
    
    public void Delete(ZtmVehicle vehicle)
    {
        _ztmVehicleRepository.Delete(vehicle);
    } 
    
}