using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RentalManagementSystem.Models.RentalsProperties
{
    public class RentalProperties
    {
        [Key]
        public int PropertyId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int FloorSize { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        public string? Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.Date;
    }
}
