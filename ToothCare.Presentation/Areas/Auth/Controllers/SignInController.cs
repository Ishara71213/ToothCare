using Microsoft.AspNetCore.Mvc;

namespace ToothCare.Presentation.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class SignInController : Controller
    {
        /*public IActionResult Index()
        {
            //ViewBag.errorMessage;
            return View("~/Areas/Auth/Views/SignIn/Index.cshtml");
        }
*/
        public IActionResult Index(string message)
        {
            ViewBag.successMessage = message;
            
            return View("~/Areas/Auth/Views/SignIn/Index.cshtml");
        }
    }
}
