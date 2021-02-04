using CachingWebApp.Data.Entities;
using System.Collections.Generic;

namespace CachingWebApp.Service
{
    public interface ILocationService
    {
        List<Province> Provinces();

        IEnumerable<District> Districts(long provinceId);

        IEnumerable<Ward> Wards(long districtId);

        List<District> Districts();

        List<Ward> Wards();
    }
}