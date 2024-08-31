using Microsoft.AspNetCore.Mvc;
using RentalManagementSystem.Data;
using RentalManagementSystem.Models;
using RentalManagementSystem.Models.RentalsProperties;
using RentalManagementSystem.Models.RoomCapacity;
using RentalManagementSystem.Models.Rooms;
using RentalManagementSystem.Models.Tenants;
using RentalManagementSystem.ViewModels;
using System.Diagnostics;

namespace RentalManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<RoomController> _logger;
        private readonly ApplicationDbcontext _dbcontext;

        public HomeController(ILogger<RoomController> logger, ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    
        public IActionResult Create()
        {
            return View();
        }
      
        public IActionResult ViewRoomCapacity()
        {
            IEnumerable<RoomType> rentalProperty = new List<RoomType>();
            return View(rentalProperty);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
