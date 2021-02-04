using CachingWebApp.Data;
using CachingWebApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CachingWebApp.Service
{
    public class LocationService : ILocationService
    {
        private readonly LocationDbContext _locationDbContext;

        public LocationService(LocationDbContext locationDbContext)
        {
            _locationDbContext = locationDbContext;
        }

        public IEnumerable<District> Districts(long provinceId)
        {
            return _locationDbContext.Districts.Where(x => x.ProvinceId == provinceId).AsNoTracking().ToList();
        }

        public List<District> Districts()
        {
            return _locationDbContext.Districts.AsNoTracking().ToList();
        }

        public List<Province> Provinces()
        {
            return _locationDbContext.Provinces.AsNoTracking().ToList();
        }

        public IEnumerable<Ward> Wards(long districtId)
        {
            return _locationDbContext.Wards.Where(x => x.DistrictId == districtId).AsNoTracking().ToList();
        }

        public List<Ward> Wards()
        {
            return _locationDbContext.Wards.AsNoTracking().ToList();
        }
    }
}