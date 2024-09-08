namespace RentalManagementSystem.Models.Renting
{
    public class RentRoomModel
    {
        public int PropertyId { get; set; }
        public int FloorId { get; set; }
        public int CurrencyId { get; set; }
        public List<int> SelectedRoomIds { get; set; } = new List<int>(); // For selected rooms
        public int TenantId { get; set; }
        public int PayModeId { get; set; }
        public double RentAmount { get; set; }
        public double Amount { get; set; }
    }
}
