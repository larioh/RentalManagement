using Microsoft.AspNetCore.Mvc;
using RentalManagementSystem.Data;
using RentalManagementSystem.Models;
using RentalManagementSystem.Models.RentalsProperties;
using RentalManagementSystem.Models.RoomCapacity;
using RentalManagementSystem.Models.Rooms;
using System.Diagnostics;

namespace RentalManagementSystem.Controllers
{
    public class PropertyController : Controller
    {
        private readonly ILogger<RoomController> _logger;
        private readonly ApplicationDbcontext _dbcontext;

        public PropertyController(ILogger<RoomController> logger, ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }

       

        public IActionResult ViewRentals()
        {
            IEnumerable<RentalProperties> rentals = _dbcontext.RentalProperties.ToList();
            return View(rentals);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( RentalProperties rentalProperties)
        {
            if (rentalProperties == null)
            {
                return BadRequest("Rental properties cannot be null.");
            }

            try
            {
                await _dbcontext.AddAsync(rentalProperties);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (ex) as needed
                
                _logger.LogError($"Error Adding Rentals : {ex.Message}");
                return StatusCode(500, "An error occurred while saving the rental properties.");
            }

            return RedirectToAction("ViewRentals"); // Assuming "ViewRentals" is an action that displays the rentals
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRental(RentalProperties rentalProperties)
        {
            var rentalsDetails = _dbcontext.RentalProperties.FirstOrDefault(x => x.PropertyId == rentalProperties.PropertyId);

            if (rentalsDetails != null)
            {
                // Update the properties with the values from the rentalProperties parameter
                rentalsDetails.Name = rentalProperties.Name;
                rentalsDetails.FloorSize = rentalProperties.FloorSize;
                rentalsDetails.Location = rentalProperties.Location;
                rentalsDetails.Status = rentalProperties.Status;
                rentalsDetails.Description = rentalProperties.Description;
                // Add other properties as needed

                _dbcontext.RentalProperties.Update(rentalsDetails);
                _dbcontext.SaveChanges();

                return RedirectToAction("ViewRentals");
            }
            else
            {
                // Handle case where the property was not found
                return NotFound();
            }
           
        }
        public IActionResult Edit(int id)
        {
            var rentalsDetails=_dbcontext.RentalProperties.FirstOrDefault(x => x.PropertyId == id);
            return View(rentalsDetails);
        }
        public IActionResult Delete(int id)
        {
            var rentalsDetails = _dbcontext.RentalProperties.FirstOrDefault(x => x.PropertyId == id);
            return View(rentalsDetails);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteRental(RentalProperties rental)
        {
            var rentalsDetails = _dbcontext.RentalProperties.FirstOrDefault(x => x.PropertyId == rental.PropertyId);
           
            if (rentalsDetails != null)
            {
                _dbcontext.RentalProperties.Remove(rentalsDetails);
                _dbcontext.SaveChanges();
                return RedirectToAction("ViewRentals"); // Redirect to the list or another page after deletion
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
