using Microsoft.AspNetCore.Mvc;
using ToothCare.Domain.Builders;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IServices;
using ToothCare.Presentation.Models;

namespace ToothCare.Presentation.Controllers
{

    public class DoctorController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IDoctorService _doctorService;
        public DoctorController(IAuthService authService, IDoctorService doctorService)
        {
            _authService = authService;
            _doctorService = doctorService;
        }
        public async Task<IActionResult> Index()
        {
            DoctorViewModel model = new DoctorViewModel();
            var user = _authService.GetCurrentUser();
            if (user != null)
            {
                model.User = user;
            }
            model.AllList = await _doctorService.GetAllAsync();

            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(DoctorViewModel model)
        {
            try
            {
                
                DoctorBuilder doctorBuilder = new DoctorBuilder();
                doctorBuilder.SetregistrationNumber(model.RegistrationNumber);

                doctorBuilder.SetFirstName(model.FirstName);
                doctorBuilder.SetLastName(model.LastName);
                doctorBuilder.SetEmail(model.Email);
                doctorBuilder.SetMobileNo(model.MobileNo);
                doctorBuilder.SetAddress(model.Address);

                doctorBuilder.SetId(model.Id);
                doctorBuilder.SetCreatedBy(_authService.GetCurrentUser()!.GetId());
                doctorBuilder.SetCreatedOn(DateTime.Now);

                Doctor entity = doctorBuilder.Build();

                await _doctorService.AddAsync(entity);
                return RedirectToAction("Index", "Doctor", new { message = "Record Added Succesfully" });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Update(DoctorViewModel model)
        {
            try
            {
                DoctorBuilder doctorBuilder = new DoctorBuilder();
                doctorBuilder.SetregistrationNumber(model.RegistrationNumber);

                doctorBuilder.SetFirstName(model.FirstName);
                doctorBuilder.SetLastName(model.LastName);
                doctorBuilder.SetEmail(model.Email);
                doctorBuilder.SetMobileNo(model.MobileNo);
                doctorBuilder.SetAddress(model.Address);

                doctorBuilder.SetId(model.Id);
                doctorBuilder.SetModifiedBy(_authService.GetCurrentUser()!.GetId());
                doctorBuilder.SetModifiedOn(DateTime.Now);

                Doctor entity = doctorBuilder.Build();

                await _doctorService.UpdateAsync(entity);
                return RedirectToAction("Index", "Doctor", new { message = "Record Updated Succesfully" });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _doctorService.DeleteAsync(id);
                return RedirectToAction("Index", "Doctor", new { message = "Record Deleted Succesfully" });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }
    }
}