using Microsoft.AspNetCore.Mvc;
using ToothCare.Domain.Interfaces.IServices;

namespace ToothCare.Presentation.Controllers
{
    public class UserSessionController : Controller
    {
        private readonly IAuthService _authService;
        public UserSessionController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult SignOutUser()
        {
            _authService.SignOut();
            return RedirectToAction("Index", "SignIn", new { area = "Auth" });
        }
    }
}
