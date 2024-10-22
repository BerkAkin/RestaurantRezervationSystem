using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Table
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Range(1, 2, ErrorMessage = "Masa tipi yalnızca 1 veya 2 olabilir.")] //1 küçük 2 büyük
        public int TableType { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}