using RentalManagementSystem.Models.RentalFloors;
using RentalManagementSystem.Models.RentalsProperties;
using RentalManagementSystem.Models.RoomCapacity;
using RentalManagementSystem.Models.Rooms;

namespace RentalManagementSystem.Metadata
{
    public class RentalMetadata
    {
        public Floors? floor { get; set; }
        public RentalProperties? RentalBuildings { get; set; }
        public RoomCapacities? Capacity { get; set; }
        public Rooms? Room { get; set; }
        public Floors? Floor { get; set; }
    }
}
