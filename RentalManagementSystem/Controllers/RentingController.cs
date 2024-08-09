using Microsoft.AspNetCore.Mvc;
using RentalManagementSystem.Data;
using RentalManagementSystem.Models;
using RentalManagementSystem.Models.RentalsProperties;
using RentalManagementSystem.Models.RoomCapacity;
using RentalManagementSystem.Models.Rooms;
using System.Diagnostics;

namespace RentalManagementSystem.Controllers
{
    public class RentingController : Controller
    {
        private readonly ILogger<RoomController> _logger;
        private readonly ApplicationDbcontext _dbcontext;

        public RentingController(ILogger<RoomController> logger, ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult ViewRentals()
        //{
        //    IEnumerable<RentalProperties> rentalProperty = _dbcontext.RentalProperty.ToList();
        //    return View(rentalProperty);
        //}
        public IActionResult Create()
        {
            return View();
        }
        //public IActionResult ViewRooms()
        //{
        //    IEnumerable<Rooms> rooms = _dbcontext.Room.ToList();
        //    return View(rooms);
        //}
        public IActionResult ViewRoomCapacity()
        {
            IEnumerable<RoomCapacities> rentalProperty = new List<RoomCapacities>();
            return View(rentalProperty);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
