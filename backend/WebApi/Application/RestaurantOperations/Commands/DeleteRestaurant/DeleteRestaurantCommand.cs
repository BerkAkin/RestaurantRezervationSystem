using AutoMapper;
using WebApi.Database;

namespace WebApi.Application.RestaurantOperations.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommand
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public DeleteRestaurantCommand(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == Id);
            if (restaurant is null)
            {
                throw new InvalidOperationException("Silinmek istenen restoran bulunamadı");
            }
            _context.Remove(restaurant);
            _context.SaveChanges();

        }
    }
}