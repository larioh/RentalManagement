using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentalManagementSystem.Data;
using RentalManagementSystem.Models;
using RentalManagementSystem.Models.RentalsProperties;
using RentalManagementSystem.Models.Renting;
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
            var fetchRooms = _dbcontext.Rooms.ToList();
            var getProperties = _dbcontext.RentalProperties.ToList();
            var rentals = getProperties.Select(g => new SelectListItem
            {
                Value = g.PropertyId.ToString(),
                Text = g.Name,
            }).ToList();
            var getFloors = _dbcontext.Floors.ToList();
            var floors = getFloors.Select(g => new SelectListItem
            {
                Value = g.FloorId.ToString(),
                Text = g.FloorNo,
            }).ToList();
            var getTenants = _dbcontext.Tenants.ToList();
            var tenant = getTenants.Select(g => new SelectListItem
            {
                Value = g.TenatId.ToString(),
                Text = g.Name,
            }).ToList();
            var getCurrency = _dbcontext.Currency.ToList();
            var currency = getCurrency.Select(g => new SelectListItem
            {
                Value = g.CurrencyId.ToString(),
                Text = g.CurrencyName,
            }).ToList();
            var getPaymode = _dbcontext.Paymode.ToList();
            var paymode = getPaymode.Select(g => new SelectListItem
            {
                Value = g.PaymodeId.ToString(),
                Text = g.Mode,
            }).ToList();
            var metaData = new RentingViewModel
            {
                GetRooms = fetchRooms,
                GetProperty = rentals,
                GetFloors = floors,
                GetTenant = tenant,
                GetCurrency = currency,
                GetPayMode = paymode,

            };
            return View(metaData);
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
