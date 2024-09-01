using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var tenants = from tenant in _dbcontext.Tenants
                          join gender in _dbcontext.GenderTypes
                          on tenant.Gender equals gender.GenderId.ToString() // assuming Gender is stored as a string
                          select new TenantViewModel
                          {
                              TenantId = tenant.TenatId,
                              Idno = tenant.Idno,
                              Name = tenant.Name,
                              PhoneNo = tenant.PhoneNo,
                              GenderName = gender.GenderName,
                              CreatedDate=tenant.CreateDate,
                              
                          };
           
            return View(tenants.ToList());
        }
        //public IActionResult GenderTypes()
        //{
        //    var gender = _dbcontext.GenderTypes.Select(g => new SexCategory
        //    {
        //        Gender = g.GenderName,
        //        GenderId = g.GenderId,
        //    }).ToList();
        //    return View(gender);
        //}
        [HttpGet]
        public IActionResult Create()
        {
            var sexCategories = _dbcontext.GenderTypes.ToList();
            var gender = sexCategories.Select(g => new SelectListItem
            {
                Value = g.GenderId.ToString(),
                Text = g.GenderName,
            }).ToList();
            var model = new TenantData
            {
                GetSexCategory = gender
            };
            return View(model);
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
