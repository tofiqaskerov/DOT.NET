
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concret.EntityFramework;
using DOT.NET.ViewModel;
using Entities.Concrete;
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
        private readonly IProjectManager _projectManager;
        private readonly IPacketManager _packetManager;
        private readonly ITeamManager _teamManager;
        private readonly IClientManager _clientManager;
        private readonly ILocationManager _locationManager;
        private readonly IContactManager _contactManager;
        public HomeController(ILogger<HomeController> logger, IBannerManager bannerManager, IServicesManager servicesManager, IAboutManager aboutManager, ICategoryManager categoryManager, IProjectManager projectManager, IPacketManager packetManager, ITeamManager teamManager, IClientManager clientManager, ILocationManager locationManager, IContactManager contactManager)
        {
            _logger = logger;
            _bannerManager = bannerManager;
            _servicesManager = servicesManager;
            _aboutManager = aboutManager;
            _categoryManager = categoryManager;
            _projectManager = projectManager;
            _packetManager = packetManager;
            _teamManager = teamManager;
            _clientManager = clientManager;
            _locationManager = locationManager;
            _contactManager = contactManager;
        }

        public IActionResult Index()
        {
            var banner = _bannerManager.GetFirst();
            var about = _aboutManager.GetFirst();
            var services = _servicesManager.GetServices();
            var category = _categoryManager.GetAll();
            var projects = _projectManager.GetAllProjects();
            var packets = _packetManager.GetPackets();
            var teams = _teamManager.GetTeams();
            var clients = _clientManager.GetAll();
            var location = _locationManager.GetFirst();
            HomeVM vm = new()
            {
               Services = services, 
               About = about,  
               Banner = banner,
               Category = category,
               Projects = projects,
               Packets = packets,
               Teams = teams,  
               Clients = clients,
               Location = location  
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult>Contact(Contact contact)
        {
             contact.IsRead = false;
            _contactManager.Add(contact);
            return Ok();

        }

        
    }
}