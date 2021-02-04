using CachingWebApp.Data.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CachingWebApp.Service.Caching
{
    public class LocationCachingService : ILocationCachingService
    {
        private readonly ILocationService _locationService;
        private readonly ICacheBase _memoryCache;
        private readonly IMemoryCache _inMemoryCache;

        public LocationCachingService(ILocationService locationService, ICacheBase memoryCache, IMemoryCache inMemoryCache)
        {
            _locationService = locationService;
            _memoryCache = memoryCache;
            _inMemoryCache = inMemoryCache;
        }

        public IEnumerable<District> Districts(long provinceId)
        {
            try
            {
                List<District> districtsCache = _memoryCache.GetOrCreate<List<District>>("DISTRICT_CACHE", TimeSpan.FromSeconds(300), _locationService.Districts);

                return districtsCache.Where(x => x.ProvinceId == provinceId);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Not found");
            }
        }

        public IEnumerable<Province> Provinces()
        {
            try
            {
                return _memoryCache.GetOrCreate<List<Province>>("PROVINCE_CACHE", TimeSpan.FromSeconds(300), _locationService.Provinces);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Not found");
            }
        }

        public IEnumerable<Ward> Wards(long districtId)
        {
            try
            {
                List<Ward> wardsCache = _memoryCache.GetOrCreate<List<Ward>>("WARD_CACHE", TimeSpan.FromSeconds(300), _locationService.Wards);

                return wardsCache.Where(x => x.DistrictId == districtId);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Not found");
            }
        }
    }
}