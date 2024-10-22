using AutoMapper;
using WebApi.Database;

namespace WebApi.Application.RestaurantOperations.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommand
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public UpdateRestaurantViewModel Model { get; set; }
        public UpdateRestaurantCommand(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == Id);
            if (restaurant is null)
            {
                throw new InvalidOperationException("Güncellenmek istenen restoran bulunamadı");
            }
            restaurant.Address = Model.Address != default ? Model.Address : restaurant.Address;
            restaurant.Email = Model.Email != default ? Model.Email : restaurant.Email;
            restaurant.PhoneNumber = Model.PhoneNumber != default ? Model.PhoneNumber : restaurant.PhoneNumber;
            restaurant.Name = Model.Name != default ? Model.Name : restaurant.Name;

            _context.SaveChanges();
        }
    }
    public class UpdateRestaurantViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}