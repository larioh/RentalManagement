using Microsoft.AspNetCore.Mvc;
using RentalManagementSystem.Data;
using RentalManagementSystem.Models;
using RentalManagementSystem.Models.RentalFloors;
using RentalManagementSystem.Models.RentalsProperties;
using RentalManagementSystem.Models.RoomCapacity;
using RentalManagementSystem.Models.Rooms;
using System.Diagnostics;

namespace RentalManagementSystem.Controllers
{
    public class RoomController : Controller
    {
        private readonly ILogger<RoomController> _logger;
        private readonly ApplicationDbcontext _dbcontext;

        public RoomController(ILogger<RoomController> logger, ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }

        public IActionResult ViewRooms()
        {
            IEnumerable<Rooms> rooms = _dbcontext.Rooms.ToList();
            return View(rooms);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rooms rooms)
        {
            if (rooms == null)
            {
                return BadRequest("Rooms cannot be null.");
            }

            try
            {
                await _dbcontext.AddAsync(rooms);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (ex) as needed

                _logger.LogError($"Error Adding Rooms : {ex.Message}");
                return StatusCode(500, "An error occurred while saving the rooms .");
            }

            return RedirectToAction("ViewRooms"); // Assuming "ViewRentals" is an action that displays the rentals
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRoom(Rooms room)
        {
            var roomDetails = _dbcontext.Rooms.FirstOrDefault(x => x.RoomId == room.RoomId);

            if (roomDetails != null)
            {
                // Update the properties with the values from the rentalProperties parameter
                roomDetails.RentalId = room.RentalId;
                roomDetails.FloorId = room.FloorId;
                roomDetails.RoomNo = room.RoomNo;
                roomDetails.RentCost = room.RentCost;
                roomDetails.Deposit = room.Deposit;
                roomDetails.RoomCapacity = room.RoomCapacity;
                roomDetails.Status = room.Status;

                // Add other properties as needed

                _dbcontext.Rooms.Update(roomDetails);
                _dbcontext.SaveChanges();

                return RedirectToAction("ViewRooms");
            }
            else
            {
                // Handle case where the property was not found
                return NotFound();
            }

        }
        public IActionResult Edit(int id)
        {
            var roomDetails = _dbcontext.Rooms.FirstOrDefault(x => x.RoomId == id);
            return View(roomDetails);
        }
        public IActionResult Delete(int id)
        {
            var roomDetails = _dbcontext.Rooms.FirstOrDefault(x => x.RoomId == id);
            return View(roomDetails);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteRoom(Rooms room)
        {
            var roomsDetails = _dbcontext.Rooms.FirstOrDefault(x => x.RoomId == room.RoomId);

            if (roomsDetails != null)
            {
                _dbcontext.Rooms.Remove(roomsDetails);
                _dbcontext.SaveChanges();
                return RedirectToAction("ViewRooms"); // Redirect to the list or another page after deletion
            }

            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
