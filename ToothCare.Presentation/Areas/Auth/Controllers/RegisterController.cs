using Microsoft.AspNetCore.Mvc;
using ToothCare.Domain.Interfaces.IRepositories;
using ToothCare.Domain.Interfaces.IServices;
using ToothCare.Presentation.Areas.Auth.Models;

namespace ToothCare.Presentation.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class RegisterController : Controller
    {
        private readonly IServiceOne _serviceOne;
        private readonly IRandomGuidRepository _randomGuidRepository;
        public RegisterController(IServiceOne serviceOne, IRandomGuidRepository randomGuidRepository)
        {
            _serviceOne = serviceOne;
            _randomGuidRepository = randomGuidRepository;
        }

        public IActionResult Index()
        {
            _serviceOne.printSomething();

            var newGuid = _serviceOne.printSomething();
            var model = new RegisterModel
            {
                Guid = newGuid,
                Timestamp = DateTime.UtcNow,
                Message = "Hello, world!"
            };

            return View("~/Areas/Auth/Views/Register/Index.cshtml", model);
        }
    }
}
