using Microsoft.AspNetCore.Mvc.Rendering;

namespace RentalManagementSystem.ViewModels
{
    public class TenantData
    {
        public int Idno { get; set; }
        
        public string? Name { get; set; }
      
        public string? PhoneNo { get; set; }
        
        public string? Gender { get; set; }
        public  IEnumerable<SelectListItem>? GetSexCategory { get; set; }
    }
}
