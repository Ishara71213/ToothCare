using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToothCare.Application.Services;
using ToothCare.Domain.Interfaces.IRepositories;
using ToothCare.Domain.Interfaces.IServices;
using ToothCare.Presentation.Models;

namespace ToothCare.Presentation.Controllers
{
    public class HomeController : Controller
    {
       // private readonly ILogger<HomeController> _logger;
        private readonly IServiceOne _serviceOne;
        private readonly IRandomGuidRepository _randomGuidRepository;

        public HomeController(IServiceOne serviceOne , IRandomGuidRepository randomGuidRepository)
        {
            _serviceOne = serviceOne;
            _randomGuidRepository = randomGuidRepository;
        }

        public IActionResult Index()
        {

            _serviceOne.printSomething();

            var newGuid = _serviceOne.printSomething();
            var model = new GuidDataViewModel
            {
                Guid = newGuid,
                Timestamp = DateTime.UtcNow,
                Message = "Hello, world!"
            };

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