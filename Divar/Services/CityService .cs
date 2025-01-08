using Divar.Db;
using Divar.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Divar.Services
{
    public class CityService : ICityService
    {
        private readonly DivarContext _context;

        public CityService(DivarContext context)
        {
            _context = context;
        }

        public async Task<City> GetCityByIdAsync(int cityId)
        {
            return await _context.Cities.FirstOrDefaultAsync(city => city.Id == cityId);
        }
    }
}
