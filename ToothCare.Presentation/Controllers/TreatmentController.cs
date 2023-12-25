using Microsoft.AspNetCore.Mvc;
using ToothCare.Application.Services;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IServices;
using ToothCare.Presentation.Models;

namespace ToothCare.Presentation.Controllers
{
    public class TreatmentController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITreatmentService _treatmentService;
        public TreatmentController(IAuthService authService ,ITreatmentService treatmentService) 
        {
            _authService = authService;
            _treatmentService = treatmentService;
        }
        public async Task<IActionResult> Index()
        {
            TreatmentViewModel model = new TreatmentViewModel();
            var user = _authService.GetCurrentUser();
            if (user != null)
            {
                model.User = user;
            }
            model.AllList= await _treatmentService.GetAllAsync();

            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(TreatmentViewModel model)
        {
            try
            {
                Treatment entity = new Treatment(model.Name, model.Price, model.AvarageMinutesPerSession);
                entity.SetCreatedBy(_authService.GetCurrentUser()!.GetId());
                entity.SetCreatedOn(DateTime.Now);

                await _treatmentService.AddAsync(entity);
                return RedirectToAction("Index", "Treatment", new { message = "Record Added Succesfully" });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Update(TreatmentViewModel model)
        {
            try
            {
                Treatment entity = new Treatment(model.Id, model.Name, model.Price, model.AvarageMinutesPerSession);
                entity.SetModifiedBy(_authService.GetCurrentUser()!.GetId());
                entity.SetModifiedOn(DateTime.Now);

                await _treatmentService.UpdateAsync(entity);
                return RedirectToAction("Index", "Treatment", new { message = "Record Updated Succesfully" });
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
                await _treatmentService.DeleteAsync(id);
                return RedirectToAction("Index", "Treatment", new { message = "Record Deleted Succesfully" });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }


    }
}
