using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILocationManager _locationManager;

        public ContactController(ILocationManager locationManager)
        {
            _locationManager = locationManager;
        }

        public IActionResult Index()
        {
            var location = _locationManager.GetFirst();
            return View(location);
        }
    }
}
