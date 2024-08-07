using System.ComponentModel.DataAnnotations;

namespace RentalManagementSystem.Models.Rooms
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        [Required]
        public int FloorId { get; set; }
        public  string? RoomNo { get; set; }
        [Required]
        public double  RentCost { get; set; }
        [Required]
        public double Deposit { get; set; }
        [Required]
        public string? RoomCapacity { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
