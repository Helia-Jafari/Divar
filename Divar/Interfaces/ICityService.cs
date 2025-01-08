using Divar.Db;

namespace Divar.Interfaces
{
    public interface ICityService
    {
        Task<City> GetCityByIdAsync(int cityId);
    }
}
