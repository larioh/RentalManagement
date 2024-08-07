using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RentalManagementSystem.Models.RentalsProperties
{
    public class RentalProperty
    {
        [Key]
        public int PropertyId { get; set; }
        public string? Name { get; set; }
        public int FloorSize { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
