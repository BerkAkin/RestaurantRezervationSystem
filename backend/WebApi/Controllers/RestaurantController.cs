using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.RestaurantOperations.Commands.CreateRestaurant;
using WebApi.Application.RestaurantOperations.Commands.DeleteRestaurant;
using WebApi.Application.RestaurantOperations.Commands.UpdateRestaurant;
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

        [HttpPost]
        public IActionResult createRestaurant([FromBody] CreateRestaurantViewModel model)
        {
            CreateRestaurantCommand command = new CreateRestaurantCommand(_context, _mapper);
            command.Model = model;
            command.Handle();
            return Ok("Oluşturma başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult deleteRestaurant(int id)
        {
            DeleteRestaurantCommand command = new DeleteRestaurantCommand(_context, _mapper);
            command.Id = id;
            command.Handle();
            return Ok("Silme başarılı");
        }

        [HttpPut("{id}")]
        public IActionResult updateRestaurant(int id, UpdateRestaurantViewModel model)
        {
            UpdateRestaurantCommand command = new UpdateRestaurantCommand(_context, _mapper);
            command.Id = id;
            command.Model = model;
            command.Handle();
            return Ok("Güncelleme başarılı");
        }




    }

}