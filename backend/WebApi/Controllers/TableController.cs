using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.TableOperations.Queries.GetTableDetails;
using WebApi.Application.TableOperations.Queries.GetTables;
using WebApi.Database;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]s")]

    public class TableController : ControllerBase
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;

        public TableController(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult getTables()
        {
            GetTablesQuery query = new GetTablesQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult getRestaurantDetail(int id)
        {
            GetTableDetailQuery query = new GetTableDetailQuery(_context, _mapper);
            query.Id = id;
            GetTableDetailViewModel result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public void createRestaurant()
        {

        }

        [HttpDelete("{id}")]
        public void deleteRestaurant(int id)
        {

        }

        [HttpPut("{id}")]
        public void updateRestaurant(int id)
        {

        }




    }

}