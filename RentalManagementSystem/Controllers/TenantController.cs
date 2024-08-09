using Microsoft.AspNetCore.Mvc;
using RentalManagementSystem.Data;
using RentalManagementSystem.Models;
using RentalManagementSystem.Models.RentalsProperties;
using RentalManagementSystem.Models.RoomCapacity;
using RentalManagementSystem.Models.Rooms;
using RentalManagementSystem.Models.Tenants;
using System.Diagnostics;

namespace RentalManagementSystem.Controllers
{
    public class TenantController : Controller
    {
        private readonly ILogger<RoomController> _logger;
        private readonly ApplicationDbcontext _dbcontext;

        public TenantController(ILogger<RoomController> logger, ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }

        public IActionResult ViewTenants()
        {
            IEnumerable<Tenants> tenants = _dbcontext.Tenants.ToList();
            return View(tenants);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tenants tenant)
        {
            if (tenant == null)
            {
                return BadRequest("Tenant cannot be null");
            }

            try
            {
                await _dbcontext.AddAsync(tenant);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (ex) as needed

                _logger.LogError($"Error Adding Tenant : {ex.Message}");
                return StatusCode(500, "An error occurred while saving the Tenant details .");
            }

            return RedirectToAction("ViewTenants"); // Assuming "ViewRentals" is an action that displays the rentals
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTeant(Tenants tenant)
        {
            var tenantDetails = _dbcontext.Tenants.FirstOrDefault(x => x.TenatId == tenant.TenatId);

            if (tenantDetails != null)
            {
                // Update the properties with the values from the rentalProperties parameter
                tenantDetails.Idno = tenant.Idno;
                tenantDetails.Name = tenant.Name;
                tenantDetails.PhoneNo = tenant.PhoneNo;
                tenantDetails.Gender = tenant.Gender;
              

                // Add other properties as needed

                _dbcontext.Tenants.Update(tenantDetails);
                _dbcontext.SaveChanges();

                return RedirectToAction("ViewTenants");
            }
            else
            {
                // Handle case where the property was not found
                return NotFound();
            }

        }
        public IActionResult Edit(int id)
        {
            var tenantDetails = _dbcontext.Tenants.FirstOrDefault(x => x.TenatId == id);
            return View(tenantDetails);
        }
        public IActionResult Delete(int id)
        {
            var tenantDetails = _dbcontext.Tenants.FirstOrDefault(x => x.TenatId == id);
            return View(tenantDetails);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteTenant(Tenants tenant)
        {
            var tenantDetails = _dbcontext.Tenants.FirstOrDefault(x => x.TenatId == tenant.TenatId);

            if (tenantDetails != null)
            {
                _dbcontext.Tenants.Remove(tenantDetails);
                _dbcontext.SaveChanges();
                return RedirectToAction("ViewTenants"); // Redirect to the list or another page after deletion
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
