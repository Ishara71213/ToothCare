using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IServices;
using ToothCare.Presentation.Models;

namespace ToothCare.Presentation.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;
        private readonly IAuthService _authService;

        public HomeController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {

            HomeViewModel model =new HomeViewModel();
            
            var user = _authService.GetCurrentUser();
            if (user != null)
            {
                model.User = user;
            }
            return View("Index", model);


        }

        public IActionResult Privacy()
        {
            return View();
        }

        /* public  Task<IActionResult> GuidData()
         {
             _serviceOne.printSomething();
             var data =  new { 
                 guid = Guid.NewGuid()
         };
             return new JsonResult(data);
         }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}