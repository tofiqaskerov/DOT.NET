using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServicesManager _servicesManager;

        public ServicesController(IServicesManager servicesManager)
        {
          _servicesManager = servicesManager;
        }

        public IActionResult Index()
        {
            var services = _servicesManager.GetServices();
            return View(services);
        }
    }
}
