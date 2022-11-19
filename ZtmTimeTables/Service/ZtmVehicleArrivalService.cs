using ZtmTimeTables.Entity;
using ZtmTimeTables.Repository;

namespace ZtmTimeTables.Service;

public class ZtmVehicleArrivalService
{
    private readonly ZtmVehicleArrivalRepository _ztmVehicleArrivalRepository;

    public ZtmVehicleArrivalService(ZtmVehicleArrivalRepository ztmVehicleArrivalRepository)
    {
        _ztmVehicleArrivalRepository = ztmVehicleArrivalRepository;
    }

    public ZtmVehicleArrival? FindById(int id)
    {
        return _ztmVehicleArrivalRepository.FindById(id);
    }

    public List<ZtmVehicleArrival> FindAll()
    {
        return _ztmVehicleArrivalRepository.FindAll();
    }
    
    public List<ZtmVehicleArrival> FindByVehicle(ZtmVehicle vehicle)
    {
        return _ztmVehicleArrivalRepository.FindByVehicle(vehicle);
    }
    
    public List<ZtmVehicleArrival> FindByStop(ZtmStop stop)
    {
        return _ztmVehicleArrivalRepository.FindByStop(stop);
    }
    
    public List<ZtmVehicleArrival> FindByStopAndVehicle(ZtmStop stop, ZtmVehicle vehicle)
    {
        return _ztmVehicleArrivalRepository.FindByStopAndVehicle(stop, vehicle);
    }
    
    public void AddZtmStop(ZtmVehicleArrival stop)
    {
        _ztmVehicleArrivalRepository.Save(stop);
    }

    public void Update(ZtmVehicleArrival stop)
    {
        _ztmVehicleArrivalRepository.Update(stop);
    }
    
    public void Delete(ZtmVehicleArrival stop)
    {
        _ztmVehicleArrivalRepository.Delete(stop);
    } 
    
}
