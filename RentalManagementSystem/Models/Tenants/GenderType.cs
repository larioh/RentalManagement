using System.ComponentModel.DataAnnotations;

namespace RentalManagementSystem.Models.Tenants
{
    public class GenderType
    {
        [Key]
        public int GenderId { get; set; }
        public string? GenderName { get; set; }
    }
}
