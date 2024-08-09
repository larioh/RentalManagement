using System.ComponentModel.DataAnnotations;

namespace RentalManagementSystem.Models.RoomCapacity
{
    public class RoomCapacities
    {
        [Key]
        public int CapacityId { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
