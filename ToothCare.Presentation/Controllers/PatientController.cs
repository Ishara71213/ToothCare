using Microsoft.AspNetCore.Mvc;
using ToothCare.Domain.Builders;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IServices;
using ToothCare.Presentation.Models;

namespace ToothCare.Presentation.Controllers
{
    public class PatientController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IPatientService _patientService;
        public PatientController(IAuthService authService, IPatientService patientService)
        {
            _authService = authService;
            _patientService = patientService;
        }
        public async Task<IActionResult> Index()
        {
            PatientViewModel model = new PatientViewModel();
            var user = _authService.GetCurrentUser();
            if (user != null)
            {
                model.User = user;
            }
            model.AllList = await _patientService.GetAllAsync();

            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(PatientViewModel model)
        {
            try
            {
                PatientBuilder patientBuilder = new PatientBuilder();
                patientBuilder.SetIllness(model.Illness);
                patientBuilder.SetAlergies(model.Alergies);
                patientBuilder.SetEmergencyContact(model.EmergencyContact);

                patientBuilder.SetFirstName(model.FirstName);
                patientBuilder.SetLastName(model.LastName);
                patientBuilder.SetEmail(model.Email);
                patientBuilder.SetMobileNo(model.MobileNo);
                patientBuilder.SetAddress(model.Address);

                patientBuilder.SetId(model.Id);
                patientBuilder.SetCreatedBy(_authService.GetCurrentUser()!.GetId());
                patientBuilder.SetCreatedOn(DateTime.Now);

                Patient entity = patientBuilder.Build();

                await _patientService.AddAsync(entity);
                return RedirectToAction("Index", "Patient", new { message = "Record Added Succesfully" });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Update(PatientViewModel model)
        {
            try
            {
                PatientBuilder patientBuilder = new PatientBuilder();
                patientBuilder.SetIllness(model.Illness);
                patientBuilder.SetAlergies(model.Alergies);
                patientBuilder.SetEmergencyContact(model.EmergencyContact);

                patientBuilder.SetFirstName(model.FirstName);
                patientBuilder.SetLastName(model.LastName);
                patientBuilder.SetEmail(model.Email);
                patientBuilder.SetMobileNo(model.MobileNo);
                patientBuilder.SetAddress(model.Address);

                patientBuilder.SetId(model.Id);
                patientBuilder.SetCreatedBy(_authService.GetCurrentUser()!.GetId());
                patientBuilder.SetCreatedOn(DateTime.Now);

                Patient entity = patientBuilder.Build();

                await _patientService.UpdateAsync(entity);
                return RedirectToAction("Index", "Patient", new { message = "Record Updated Succesfully" });
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
                await _patientService.DeleteAsync(id);
                return RedirectToAction("Index", "Patient", new { message = "Record Deleted Succesfully" });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }
    }
}