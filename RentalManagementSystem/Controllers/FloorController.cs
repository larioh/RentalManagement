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
    public class FloorController : Controller
    {
        private readonly ILogger<FloorController> _logger;
        private readonly ApplicationDbcontext _dbcontext;

        public FloorController(ILogger<FloorController> logger, ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }

        public IActionResult ViewFloors()
        {
            IEnumerable<Floors> floors = _dbcontext.Floors.ToList();
            return View(floors);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Floors floors)
        {
            if (floors == null)
            {
                return BadRequest("Rental Floors cannot be null.");
            }

            try
            {
                await _dbcontext.AddAsync(floors);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (ex) as needed

                _logger.LogError($"Error Adding Floors : {ex.Message}");
                return StatusCode(500, "An error occurred while saving the rooms .");
            }

            return RedirectToAction("ViewFloors"); // Assuming "ViewRentals" is an action that displays the rentals
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditFloor(Floors floor)
        {
            var floorDetails = _dbcontext.Floors.FirstOrDefault(x => x.FloorId == floor.FloorId);

            if (floorDetails != null)
            {
                // Update the properties with the values from the rentalProperties parameter
                floorDetails.FloorNo = floor.FloorNo;
                floorDetails.PropertyId = floor.PropertyId;
                floorDetails.RoomSize = floor.RoomSize;
                floorDetails.Status = floor.Status;
                
                // Add other properties as needed

                _dbcontext.Floors.Update(floorDetails);
                _dbcontext.SaveChanges();

                return RedirectToAction("ViewFloors");
            }
            else
            {
                // Handle case where the property was not found
                return NotFound();
            }

        }
        public IActionResult Edit(int id)
        {
            var floorDetails = _dbcontext.Floors.FirstOrDefault(x => x.FloorId == id);
            return View(floorDetails);
        }
        public IActionResult Delete(int id)
        {
            var floorDetails = _dbcontext.Floors.FirstOrDefault(x => x.FloorId == id);
            return View(floorDetails);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFloor(Floors floors)
        {
            var floorsDetails = _dbcontext.Floors.FirstOrDefault(x => x.FloorId == floors.FloorId);

            if (floorsDetails != null)
            {
                _dbcontext.Floors.Remove(floorsDetails);
                _dbcontext.SaveChanges();
                return RedirectToAction("ViewFloors"); // Redirect to the list or another page after deletion
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
