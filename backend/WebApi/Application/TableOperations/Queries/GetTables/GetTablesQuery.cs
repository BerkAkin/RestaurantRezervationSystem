using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Database;
using WebApi.Entities;

namespace WebApi.Application.TableOperations.Queries.GetTables
{
    public class GetTablesQuery
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;

        public GetTablesQuery(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetTablesViewModel> Handle()
        {
            var tables = _context.Tables.ToList();
            if (tables is null)
            {
                throw new InvalidOperationException("Masalar bulunamadı");
            }
            List<GetTablesViewModel> vm = _mapper.Map<List<GetTablesViewModel>>(tables);
            return vm;

        }
    }
    public class GetTablesViewModel
    {
        public int TableType { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
        public int RestaurantId { get; set; }
    }
}