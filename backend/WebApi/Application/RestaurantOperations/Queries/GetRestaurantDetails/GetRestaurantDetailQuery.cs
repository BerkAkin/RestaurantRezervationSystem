using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Database;
using WebApi.Entities;

namespace WebApi.Application.RestaurantOperations.Queries.GetRestaurantDetails
{
    public class GetRestaurantDetailQuery
    {
        private readonly IMapper _mapper;
        private readonly RestaurantDbContext _context;
        public int Id { get; set; }
        public GetRestaurantDetailQuery(RestaurantDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public GetRestaurantDetailViewModel Handle()
        {
            var restaurant = _context.Restaurants.Include(r => r.Tables).FirstOrDefault(t => t.Id == Id);
            if (restaurant is null)
            {
                throw new InvalidOperationException("Restoran bulunamadı");
            }
            GetRestaurantDetailViewModel vm = _mapper.Map<GetRestaurantDetailViewModel>(restaurant);
            return vm;
        }
    }
    public class GetRestaurantDetailViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<RestaurantTablesViewModel> Tables { get; set; }
    }
    public class RestaurantTablesViewModel
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
        public int TableType { get; set; }
    }
}