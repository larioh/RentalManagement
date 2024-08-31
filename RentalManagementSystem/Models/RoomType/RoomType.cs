using System.ComponentModel.DataAnnotations;

namespace RentalManagementSystem.Models.RoomCapacity
{
    public class RoomType
    {
        [Key]
        public int CapacityId { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
