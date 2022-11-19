using ZtmTimeTables.Entity;
using ZtmTimeTables.Repository;

namespace ZtmTimeTables.Service;

public class ZtmStopService
{
    private readonly ZtmStopRepository _ztmStopRepository;

    public ZtmStopService(ZtmStopRepository ztmStopRepository)
    {
        _ztmStopRepository = ztmStopRepository;
    }

    public ZtmStop? FindById(int id)
    {
        return _ztmStopRepository.FindById(id);
    }

    public List<ZtmStop> FindAll()
    {
        return _ztmStopRepository.FindAll();
    }
    
    public void AddZtmStop(ZtmStop stop)
    {
        _ztmStopRepository.Save(stop);
    }

    public void Update(ZtmStop stop)
    {
        _ztmStopRepository.Update(stop);
    }
    
    public void Delete(ZtmStop stop)
    {
        _ztmStopRepository.Delete(stop);
    }
    
}