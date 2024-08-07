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
        public List<Room>? Room { get; set; }
        [Required]
        public Occupant?  Tenant { get; set; }

    }
}
