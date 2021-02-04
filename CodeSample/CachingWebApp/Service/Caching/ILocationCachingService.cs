using CachingWebApp.Data.Entities;
using System.Collections.Generic;

namespace CachingWebApp.Service.Caching
{
    public interface ILocationCachingService
    {
        IEnumerable<Province> Provinces();

        IEnumerable<District> Districts(long provinceId);

        IEnumerable<Ward> Wards(long districtId);
    }
}
