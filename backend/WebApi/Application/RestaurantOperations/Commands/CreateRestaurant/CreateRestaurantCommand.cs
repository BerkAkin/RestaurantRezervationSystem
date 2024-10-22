using AutoMapper;
using WebApi.Database;
using WebApi.Entities;

namespace WebApi.Application.RestaurantOperations.Commands.CreateRestaurant
{
    public class CreateRestaurantCommand
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;
        public CreateRestaurantViewModel Model { get; set; }
        public CreateRestaurantCommand(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var restaraunt = _context.Restaurants.SingleOrDefault(r => r.PhoneNumber == Model.PhoneNumber);
            if (restaraunt is not null)
            {
                throw new InvalidOperationException("Restoran zaten mevcut. Tel No Kontrol Edin");
            }
            restaraunt = _mapper.Map<Restaurant>(Model);
            _context.Restaurants.Add(restaraunt);
            _context.SaveChanges();


        }
    }
    public class CreateRestaurantViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

}