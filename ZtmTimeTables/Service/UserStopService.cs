using ZtmTimeTables.Entity;
using ZtmTimeTables.Repository;

namespace ZtmTimeTables.Service;

public class UserStopService
{
    private readonly UserStopRepository _userStopRepository;

    public UserStopService(UserStopRepository userStopRepository)
    {
        _userStopRepository = userStopRepository;
    }

    public List<UserStop> FindAllUserStops(User user)
    {
        return _userStopRepository.FindAllByUser(user);
    }

    public UserStop? FindByStopIdAndUser(int stopId, User user)
    {
        return _userStopRepository.FindAllByUser(user).Where(us => us.StopId == stopId).First();
    }

    public void AddUserStop(UserStop stop)
    {
        _userStopRepository.Save(stop);
    }

    public void RemoveUserStop(UserStop stop)
    {
        _userStopRepository.Remove(stop);
    }
}