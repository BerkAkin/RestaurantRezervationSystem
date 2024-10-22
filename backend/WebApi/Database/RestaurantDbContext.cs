using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Database
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {

        }

        public DbSet<Table> Tables { get; set; }
    }
}