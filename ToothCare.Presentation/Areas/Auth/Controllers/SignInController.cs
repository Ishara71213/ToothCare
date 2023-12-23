using Microsoft.AspNetCore.Mvc;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IServices;
using ToothCare.Presentation.Areas.Auth.Models;

namespace ToothCare.Presentation.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class SignInController : Controller
    {
        private readonly IAuthService _authService;
        public SignInController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index(string message)
        {
            ViewBag.successMessage = message;
            ViewBag.errorMessage = TempData["ErrorMessage"] as string;

            if (_authService.IsAuthenticated())
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return View("~/Areas/Auth/Views/SignIn/Index.cshtml");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel signinData)
        {
            try
            {
                await _authService.SignIn(signinData.Email, signinData.Password);
                return RedirectToAction("Index", "Home", new { area = "" });
                //return RedirectToAction("Index", new { message = "User Logged In Succesfully" });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }
    }
}
