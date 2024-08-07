using Microsoft.EntityFrameworkCore;
using RentalManagementSystem.Models.Bookings;
using RentalManagementSystem.Models.RentalFloors;
using RentalManagementSystem.Models.RentalsProperties;
using RentalManagementSystem.Models.Rooms;

namespace RentalManagementSystem.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) :base(options) 
        { }


        public DbSet<Bookings> Books {get; set;}
        public DbSet<Floors> Floors { get; set; }
        public DbSet<RentalProperty> RentalProperties { get; set; }
        public DbSet<Room> Rooms { get; set; }

    }
}
