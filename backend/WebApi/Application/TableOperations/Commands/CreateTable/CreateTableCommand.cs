using AutoMapper;
using WebApi.Database;
using WebApi.Entities;

namespace WebApi.Application.TableOperations.Commands.CreateTable
{
    public class CreateTableCommand
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;
        public CreateTableViewModel Model { get; set; }

        public CreateTableCommand(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var table = _mapper.Map<Table>(Model);
            _context.Tables.Add(table);
            _context.SaveChanges();
        }
    }

    public class CreateTableViewModel
    {
        public int TableType { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
        public int RestaurantId { get; set; }
    }
}