using System.ComponentModel.DataAnnotations;

namespace RentalManagementSystem.Models.RoomCapacity
{
    public class RoomCapacity
    {
        [Key]
        public int CapacityId { get; set; }
        public string? Name { get; set; }
    }
}
