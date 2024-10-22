using WebApi.Database;
using WebApi.Entities;

public class DbSeeder
{
    public static void Seed(RestaurantDbContext context)
    {
        if (!context.Restaurants.Any())
        {
            var restaurant = new Restaurant
            {
                Name = "Örnek Restoran",
                Address = "Örnek Adres",
                PhoneNumber = "123456789",
                Email = "example@example.com",
            };

            context.Restaurants.Add(restaurant);
            context.SaveChanges();

            // 10 adet küçük masa
            for (int i = 0; i < 10; i++)
            {
                context.Tables.Add(new Table
                {
                    TableType = 1,
                    Capacity = 2,  // Küçük masa kapasitesi
                    RestaurantId = restaurant.Id,
                    IsAvailable = true
                });
            }

            // 10 adet büyük masa
            for (int i = 0; i < 10; i++)
            {
                context.Tables.Add(new Table
                {
                    TableType = 2,
                    Capacity = 4,  // Büyük masa kapasitesi
                    RestaurantId = restaurant.Id,
                    IsAvailable = true
                });
            }

            context.SaveChanges(); // Değişiklikleri kaydedin
        }
    }
}
