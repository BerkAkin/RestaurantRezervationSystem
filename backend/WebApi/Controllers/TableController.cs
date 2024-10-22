using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.TableOperations.Commands.CreateTable;
using WebApi.Application.TableOperations.Commands.DeleteTable;
using WebApi.Application.TableOperations.Commands.UpdateTable;
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
        public IActionResult getTableDetail(int id)
        {
            GetTableDetailQuery query = new GetTableDetailQuery(_context, _mapper);
            query.Id = id;
            GetTableDetailViewModel result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult createTable([FromBody] CreateTableViewModel model)
        {
            CreateTableCommand command = new CreateTableCommand(_context, _mapper);
            command.Model = model;
            command.Handle();
            return Ok("Oluşturma başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult deleteTable(int id)
        {
            DeleteTableCommand command = new DeleteTableCommand(_context, _mapper);
            command.Id = id;
            command.Handle();
            return Ok("Silme başarılı");
        }

        [HttpPut("{id}")]
        public IActionResult updateTable(int id, [FromBody] UpdateTableViewModel Model)
        {
            UpdateTableCommand command = new UpdateTableCommand(_context, _mapper);
            command.Id = id;
            command.Model = Model;
            command.Handle();
            return Ok("Güncelleme başarılı");
        }




    }

}