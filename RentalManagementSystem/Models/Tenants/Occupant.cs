using System.ComponentModel.DataAnnotations;

namespace RentalManagementSystem.Models.Tenants
{
    public class Occupant
    {
        [Key]
        public int TenatId { get; set; }
        [Required]
        public int Idno { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? PhoneNo { get; set; }
        [Required]
        public string? Gender { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
