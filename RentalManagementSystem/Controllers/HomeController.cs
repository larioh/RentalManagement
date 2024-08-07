using Microsoft.AspNetCore.Mvc;
using RentalManagementSystem.Data;
using RentalManagementSystem.Models;
using RentalManagementSystem.Models.RentalsProperties;
using RentalManagementSystem.Models.RoomCapacity;
using RentalManagementSystem.Models.Rooms;
using System.Diagnostics;

namespace RentalManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbcontext _dbcontext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewRentals()
        {
            IEnumerable<RentalProperty> rentalProperty = _dbcontext.RentalProperties.ToList();
            return View(rentalProperty);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult ViewRooms()
        {
            IEnumerable<Room> rentalProperty = _dbcontext.Rooms.ToList();
            return View(rentalProperty);
        }
        public IActionResult ViewRoomCapacity()
        {
            IEnumerable<RoomCapacity> rentalProperty = new List<RoomCapacity>();
            return View(rentalProperty);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}