using System.ComponentModel.DataAnnotations;

namespace RentalManagementSystem.Models.RentalFloors
{
    public class Floors
    {
        [Key]
        public int FloorId { get; set; }
        [Required]
        public int PropertyId { get; set; }
        [Required]
        public string? FloorNo { get; set; }
        [Required]
        public int RoomSize { get; set; }
        
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
