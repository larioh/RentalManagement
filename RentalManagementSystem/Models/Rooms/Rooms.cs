using System.ComponentModel.DataAnnotations;

namespace RentalManagementSystem.Models.Rooms
{
    public class Rooms
    {
        [Key]
        public int RoomId { get; set; }
        [Required]
        public int RentalId { get; set; }
        [Required]
        public int FloorId { get; set; }
        [Required]
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
