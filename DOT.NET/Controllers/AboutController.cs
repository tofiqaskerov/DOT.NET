using Business.Abstract;
using DOT.NET.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutManager _aboutManager;
        private readonly IConnectionManager _connectionManager;
        public AboutController(IAboutManager aboutManager, IConnectionManager connectionManager)
        {
            _aboutManager = aboutManager;
            _connectionManager = connectionManager;
        }

        public IActionResult Index()
        {
            var about = _aboutManager.GetFirst();
            var connection = _connectionManager.GetAll();
            AboutVM vm = new()
            {
                About = about,
                Connections = connection
            };
            return View(vm);
        }
    }
}
