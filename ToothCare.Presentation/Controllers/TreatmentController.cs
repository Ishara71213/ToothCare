using Microsoft.AspNetCore.Mvc;

namespace ToothCare.Presentation.Controllers
{
    public class TreatmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
