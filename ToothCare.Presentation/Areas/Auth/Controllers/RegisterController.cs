using Microsoft.AspNetCore.Mvc;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IRepositories;
using ToothCare.Domain.Interfaces.IServices;
using ToothCare.Presentation.Areas.Auth.Models;

namespace ToothCare.Presentation.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class RegisterController : Controller
    {
        private readonly IServiceOne _serviceOne;
        private readonly IRegisterService _registerService;
        public RegisterController(IServiceOne serviceOne, IRegisterService registerService)
        {
            _serviceOne = serviceOne;
            _registerService = registerService;
        }

        public IActionResult Index()
        {
            var errorMessage = TempData["ErrorMessage"] as string;

            /*_serviceOne.printSomething();

            Patient patient = new();
            patient.Address = "test address";
            patient.CreatedOn= DateTime.Now;

            var newGuid = _serviceOne.printSomething();*/
            var model = new RegisterViewModel
            {
                
            };

            return View("~/Areas/Auth/Views/Register/Index.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerData)
        {
            try
            {
                var model = new Staff
                {
                    Id = 1,
                    FirstName = registerData.FirstName,
                    LastName = registerData.LastName,
                    Email = registerData.Email,
                    Address = registerData.Address,
                    EncryptedPassword = registerData.Password,
                    MobileNo = registerData.MobileNo,
                    CreatedOn = DateTime.Now,

                };

                await _registerService.RegisterUser(model);
                return RedirectToAction("Index", "SignIn", new { message = "User Created Succesfully" } );
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
            
        }
    }
}
