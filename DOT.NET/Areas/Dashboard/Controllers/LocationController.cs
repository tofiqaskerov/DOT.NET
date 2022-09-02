using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class LocationController : Controller
    {
        private readonly ILocationManager _locationManager;

        public LocationController(ILocationManager locationManager)
        {
            _locationManager = locationManager;
        }

        public IActionResult Index()
        {
            var location = _locationManager.GetFirst();
            return View(location);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var location = _locationManager.GetFirst();
            if (location != null) return RedirectToAction("Index");
            return View();
        }


        [HttpPost]
        public IActionResult Create(Location location)
        {
            try
            {
                _locationManager.Add(location);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
           
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var location = _locationManager.Get(id);
            return View(location);
        }


        [HttpPost]
        public IActionResult Edit(Location location)
        {
            try
            {
                _locationManager.Update(location);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        

 
        
    }
}
