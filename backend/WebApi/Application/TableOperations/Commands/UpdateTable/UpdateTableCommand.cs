using AutoMapper;
using WebApi.Database;

namespace WebApi.Application.TableOperations.Commands.UpdateTable
{
    public class UpdateTableCommand
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public UpdateTableViewModel Model { get; set; }

        public UpdateTableCommand(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var table = _context.Tables.FirstOrDefault(r => r.Id == Id);
            if (table is null)
            {
                throw new InvalidOperationException("Masa bulunamadı");
            }
            table.Capacity = Model.Capacity != default ? Model.Capacity : table.Capacity;
            table.IsAvailable = Model.IsAvailable != default ? Model.IsAvailable : table.IsAvailable;
            table.TableType = Model.TableType != default ? Model.TableType : table.TableType;
            table.RestaurantId = Model.RestaurantId != default ? Model.RestaurantId : table.RestaurantId;
            _context.SaveChanges();
        }
    }

    public class UpdateTableViewModel
    {
        public int TableType { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
        public int RestaurantId { get; set; }
    }
}