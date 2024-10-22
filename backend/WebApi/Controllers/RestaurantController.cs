using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.RestaurantOperations.Queries.GetRestaurant;
using WebApi.Application.RestaurantOperations.Queries.GetRestaurantDetails;
using WebApi.Database;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]s")]

    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;

        public RestaurantController(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult getRestaurants()
        {
            GetRestaurantQuery query = new GetRestaurantQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult getRestaurantDetail(int id)
        {
            GetRestaurantDetailQuery query = new GetRestaurantDetailQuery(_context, _mapper);
            query.Id = id;
            var result = query.Handle();
            return Ok(result);
        }



    }

}