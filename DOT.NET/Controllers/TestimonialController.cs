using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IClientManager _clientManager;

        public TestimonialController(IClientManager clientManager)
        {
            _clientManager = clientManager;
        }

        public IActionResult Index()
        {
            var clients = _clientManager.GetAll();
            return View(clients);
        }
    }
}
