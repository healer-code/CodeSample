using CachingWebApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CachingWebApp.Data
{
    public class LocationDbContext : DbContext
    {
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ward> Wards { get; set; }

        public LocationDbContext(DbContextOptions<LocationDbContext> options) : base(options)
        {
        }
    }
}