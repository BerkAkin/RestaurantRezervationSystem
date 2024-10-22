using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Database;
using WebApi.Entities;

namespace WebApi.Application.RestaurantOperations.Queries.GetRestaurant
{
    public class GetRestaurantQuery
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;
        public GetRestaurantQuery(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetRestaurantViewModel> Handle()
        {

            List<Restaurant> restaurants = _context.Restaurants.ToList();
            if (restaurants is null)
            {
                throw new InvalidOperationException("Restoranlar bulunamadı");
            }
            List<GetRestaurantViewModel> vm = _mapper.Map<List<GetRestaurantViewModel>>(restaurants);
            return vm;
        }

    }
    public class GetRestaurantViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}