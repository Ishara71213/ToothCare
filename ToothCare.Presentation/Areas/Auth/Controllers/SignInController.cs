using Microsoft.AspNetCore.Mvc;

namespace ToothCare.Presentation.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class SignInController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Auth/Views/SignIn/Index.cshtml");
        }
    }
}
