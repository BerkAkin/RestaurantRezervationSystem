using AutoMapper;
using WebApi.Database;

namespace WebApi.Application.TableOperations.Commands.DeleteTable
{
    public class DeleteTableCommand
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public DeleteTableCommand(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var table = _context.Tables.FirstOrDefault(r => r.Id == Id);
            if (table is null)
            {
                throw new InvalidOperationException("Silinecek masa bulunamadı");
            }
            _context.Tables.Remove(table);
            _context.SaveChanges();

        }
    }
}