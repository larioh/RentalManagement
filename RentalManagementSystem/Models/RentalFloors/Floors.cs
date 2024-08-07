using System.ComponentModel.DataAnnotations;

namespace RentalManagementSystem.Models.RentalFloors
{
    public class Floors
    {
        [Key]
        public int FloorId { get; set; }
        public int PropertyId { get; set; }

        public string? FloorNo { get; set; }
       
        public int RoomSize { get; set; }
        
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
