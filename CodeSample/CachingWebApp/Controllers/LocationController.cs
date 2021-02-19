using CachingWebApp.Service;
using CachingWebApp.Service.Caching;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CachingWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly ILocationCachingService _locationCachingService;

        public LocationController(ILocationService locationService, ILocationCachingService locationCachingService)
        {
            _locationService = locationService;
            _locationCachingService = locationCachingService;
        }

        //[HttpGet("Provinces")]
        //public async Task<JsonResult> Provinces()
        //{
        //    try
        //    {
        //        return new JsonResult(_locationCachingService.Provinces());
        //    }
        //    catch (Exception ex)
        //    {
        //        return new JsonResult(ex.Message);
        //    }
        //}

        //[HttpGet("Districts")]
        //public async Task<JsonResult> Districts(int provinceId)
        //{
        //    try
        //    {
        //        return new JsonResult(_locationCachingService.Districts(provinceId));
        //    }
        //    catch (Exception ex)
        //    {
        //        return new JsonResult(ex.Message);
        //    }
        //}

        //[HttpGet("Wards")]
        //public async Task<JsonResult> Wards(int districtId)
        //{
        //    try
        //    {
        //        return new JsonResult(_locationService.Wards(districtId));
        //    }
        //    catch (Exception ex)
        //    {
        //        return new JsonResult(ex.Message);
        //    }
        //}

        [HttpGet("Provinces")]
        public async Task<JsonResult> Provinces()
        {
            try
            {
                return new JsonResult(_locationService.Provinces());
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpGet("Districts")]
        [Authorize]
        public async Task<JsonResult> Districts(int provinceId)
        {
            try
            {
                return new JsonResult(_locationService.Districts(provinceId));
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpGet("Wards")]
        public async Task<JsonResult> Wards(int districtId)
        {
            try
            {
                return new JsonResult(_locationService.Wards(districtId));
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
    }
}