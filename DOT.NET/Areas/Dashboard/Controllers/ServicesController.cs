using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class ServicesController : Controller
    {
        private readonly IServicesManager _servicesManager;
        private readonly ICategoryManager _categoryManager;

        public ServicesController(IServicesManager servicesManager, ICategoryManager categoryManager)
        {
            _servicesManager = servicesManager;
            _categoryManager = categoryManager;
        }

        public IActionResult Index()
        {
            var service = _servicesManager.GetServices();
            ViewBag.ServicesLimit = service.Count();
            return View(service);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var category = _categoryManager.GetAll();
            if(category.Count() > 3)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Category = category;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Services services)
        {
            try
            {
                _servicesManager.Add(services);
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
            var services = _servicesManager.Get(id);
            ViewData["category"] = _categoryManager.GetAll();
            return View(services);
        }
        [HttpPost]
        public IActionResult Edit(Services services)
        {
            _servicesManager.Update(services);
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var services = _servicesManager.Get(id);
            if (services == null) return NotFound();
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Services services)
        {
            try
            {

                _servicesManager.Remove(services);
                return RedirectToAction("Index");
                
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
