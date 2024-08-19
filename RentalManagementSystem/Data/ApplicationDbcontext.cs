using Microsoft.EntityFrameworkCore;
using RentalManagementSystem.Models.Bookings;
using RentalManagementSystem.Models.RentalFloors;
using RentalManagementSystem.Models.RentalsProperties;
using RentalManagementSystem.Models.RoomCapacity;
using RentalManagementSystem.Models.Rooms;
using RentalManagementSystem.Models.Tenants;

namespace RentalManagementSystem.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) :base(options) 
        { }

        public DbSet<GenderType> GenderTypes { get; set; }
        public DbSet<Bookings> Bookings { get; set;}
        public DbSet<Floors> Floors { get; set; }
        public DbSet<RentalProperties> RentalProperties { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<RoomCapacities> RoomCapacities { get; set; }
        public DbSet<Tenants> Tenants { get; set; }
        
        

    }
}
