
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concret.EntityFramework;
using DOT.NET.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DOT.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBannerManager _bannerManager;
        private readonly IAboutManager _aboutManager;
        private readonly IServicesManager _servicesManager;
        private readonly ICategoryManager _categoryManager;
        public HomeController(ILogger<HomeController> logger, IBannerManager bannerManager, IServicesManager servicesManager, IAboutManager aboutManager, ICategoryManager categoryManager)
        {
            _logger = logger;
            _bannerManager = bannerManager;
            _servicesManager = servicesManager;
            _aboutManager = aboutManager;
            _categoryManager = categoryManager;
        }

        public IActionResult Index()
        {
            var banner = _bannerManager.GetFirst();
            var about = _aboutManager.GetFirst();
            var services = _servicesManager.GetServices();
            var category = _categoryManager.GetAll();

            HomeVM vm = new()
            {
               Services = services, 
               About = about,  
               Banner = banner,
               Category = category,
            };
            return View(vm);
        }

        
    }
}