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
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Table>()
                .HasOne(t => t.Restaurant)
                .WithMany(r => r.Tables)
                .HasForeignKey(t => t.RestaurantId);

            modelBuilder.Entity<Restaurant>()
               .HasMany(r => r.Tables)
               .WithOne(t => t.Restaurant)
               .HasForeignKey(t => t.RestaurantId);
        }
    }
}