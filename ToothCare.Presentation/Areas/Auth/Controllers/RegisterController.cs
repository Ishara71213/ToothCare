using Microsoft.AspNetCore.Mvc;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IServices;
using ToothCare.Presentation.Areas.Auth.Models;

namespace ToothCare.Presentation.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class RegisterController : Controller
    {
        private readonly IRegisterService _registerService;
        private readonly IAuthService _authService;
        public RegisterController(IAuthService authService, IRegisterService registerService)
        {
            _registerService = registerService;
            _authService = authService;
        }

        public IActionResult Index()
        {
            var errorMessage = TempData["ErrorMessage"] as string;

            var model = new RegisterViewModel
            {

            };

            if (_authService.IsAuthenticated())
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return View("~/Areas/Auth/Views/Register/Index.cshtml", model);
            }
            
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
                return RedirectToAction("Index", "SignIn", new { message = "User Created Succesfully" });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }
    }
}
