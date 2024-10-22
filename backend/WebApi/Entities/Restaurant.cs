using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Restaurant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Table> Tables { get; set; }

    }
}