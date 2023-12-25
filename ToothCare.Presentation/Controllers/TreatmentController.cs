using Microsoft.AspNetCore.Mvc;
using ToothCare.Application.Services;
using ToothCare.Domain.Builders;
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
                TreatmentBuilder builder = new TreatmentBuilder();

                builder.SetName(model.Name);
                builder.SetPrice(model.Price);
                builder.SetAverageMinutesPerSession(model.AvarageMinutesPerSession);

                builder.SetId(model.Id);
                builder.SetCreatedBy(_authService.GetCurrentUser()!.GetId());
                builder.SetCreatedOn(DateTime.Now);

                Treatment entity = builder.Build();

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
                TreatmentBuilder builder = new TreatmentBuilder();

                builder.SetName(model.Name);
                builder.SetPrice(model.Price);
                builder.SetAverageMinutesPerSession(model.AvarageMinutesPerSession);

                builder.SetId(model.Id);
                builder.SetModifiedBy(_authService.GetCurrentUser()!.GetId());
                builder.SetModifiedOn(DateTime.Now);

                Treatment entity = builder.Build();

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
