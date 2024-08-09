using RentalManagementSystem.Models.RentalsProperties;
using RentalManagementSystem.Models.Rooms;
using RentalManagementSystem.Models.Tenants;
using System.ComponentModel.DataAnnotations;

namespace RentalManagementSystem.Models.Bookings
{
    public class Bookings
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public int FloorId { get; set; }
        [Required]
        public int RentalId { get; set; }
        [Required]
        public int TenantId { get; set; }

    }
}
