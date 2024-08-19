using Microsoft.AspNetCore.Mvc.Rendering;

namespace RentalManagementSystem.ViewModels
{
    public class FloorViewModel
    {
        
       
        public string? FloorNo { get; set; }
        
        public int RoomSize { get; set; }
        public int PropertyId { get; set; }
        public IEnumerable<SelectListItem>? GetRentalProperty { get; set; }
        
    }
}
