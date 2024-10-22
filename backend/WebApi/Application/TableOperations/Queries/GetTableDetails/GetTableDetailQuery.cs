using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Database;
using WebApi.Entities;

namespace WebApi.Application.TableOperations.Queries.GetTableDetails
{
    public class GetTableDetailQuery
    {
        private readonly IMapper _mapper;
        private readonly RestaurantDbContext _context;
        public int Id { get; set; }
        public GetTableDetailQuery(RestaurantDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public GetTableDetailViewModel Handle()
        {
            var table = _context.Tables.FirstOrDefault(t => t.Id == Id);
            if (table is null)
            {
                throw new InvalidOperationException("Masa bulunamadı");
            }
            GetTableDetailViewModel vm = _mapper.Map<GetTableDetailViewModel>(table);
            return vm;
        }
    }
    public class GetTableDetailViewModel
    {
        public int TableType { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
        public int RestaurantId { get; set; }
    }

}