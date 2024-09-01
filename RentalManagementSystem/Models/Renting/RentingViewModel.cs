using Microsoft.AspNetCore.Mvc.Rendering;

namespace RentalManagementSystem.Models.Renting
{
    public class RentingViewModel
    {
        public int Room { get; set; }
        public int Property { get; set; }
        public int Floor { get; set; }
        public int Currency { get; set; }
        public int Tenant { get; set; }
        public int PayMode { get; set; }
        public double Amount { get; set; }
        public List<Rooms.Rooms>? GetRooms { get; set; }
        public IEnumerable<SelectListItem>? GetProperty { get; set; }
        public IEnumerable<SelectListItem>? GetFloors { get; set; }
        public IEnumerable<SelectListItem>? GetCurrency { get; set; }
        public IEnumerable<SelectListItem>? GetTenant { get; set; }
        public IEnumerable<SelectListItem>? GetPayMode { get; set; }

    }
}
