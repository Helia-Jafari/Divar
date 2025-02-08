using Divar.Db;
using Divar.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Divar.Services
{
    public class CityService : ICityService
    {
        private readonly DivarContext _context;
        private readonly IDistributedCache _cache;

        public CityService(DivarContext context, IDistributedCache memoryCache)
        {
            _context = context;
            _cache = memoryCache;
        }

        public async Task<City> GetCityByIdAsync(int cityId)
        {
            //const string cacheKey = "city";
            //if (!_cache.TryGetValue(cacheKey, out City city))
            //{
            //    city = await _context.Cities.FirstOrDefaultAsync(city => city.Id == cityId);
            //    _cache.Set(cacheKey, city, TimeSpan.FromMinutes(10)); // مدت زمان کشینگ
            //}
            //return city;

            string cacheKey = $"city{cityId}";
            var cachedData = await _cache.GetStringAsync(cacheKey);
            if (cachedData.IsNullOrEmpty())
            {
                var city = await _context.Cities.FirstOrDefaultAsync(city => city.Id == cityId);
                var serializedCity = JsonSerializer.Serialize(city, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    WriteIndented = true
                }); ;
                await _cache.SetStringAsync(cacheKey, serializedCity, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                });
                return city;
            }
            var cachedCity = JsonSerializer.Deserialize<City>(cachedData, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            ;
            return cachedCity;
        }
    }
}
