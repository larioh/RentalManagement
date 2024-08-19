using RentalManagementSystem.Models.RentalFloors;
using RentalManagementSystem.Models.RentalsProperties;
using RentalManagementSystem.Models.RoomCapacity;
using RentalManagementSystem.Models.Rooms;

namespace RentalManagementSystem.Metadata
{
    public class RentalMetadata
    {
        
        public RentalProperties? RentalBuilding { get; set; }
        public RoomCapacities? Capacity { get; set; }
        public Rooms? Room { get; set; }
        public Floors? Floor { get; set; }
    }
}
