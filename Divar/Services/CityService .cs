using Divar.Db;
using Divar.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Divar.Services
{
    public class CityService : ICityService
    {
        private readonly DivarContext _context;
        private readonly IMemoryCache _cache;

        public CityService(DivarContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _cache = memoryCache;
        }

        public async Task<City> GetCityByIdAsync(int cityId)
        {
            const string cacheKey = "city";
            if (!_cache.TryGetValue(cacheKey, out City city))
            {
                city = await _context.Cities.FirstOrDefaultAsync(city => city.Id == cityId);
                _cache.Set(cacheKey, city, TimeSpan.FromMinutes(10)); // مدت زمان کشینگ
            }
            return city;
        }
    }
}
