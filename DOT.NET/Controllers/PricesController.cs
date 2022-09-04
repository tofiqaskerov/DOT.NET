using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Controllers
{
    public class PricesController : Controller
    {
        private readonly IPacketManager _packetManager;

        public PricesController(IPacketManager packetManager)
        {
            _packetManager = packetManager;
        }

        public IActionResult Index()
        {
            var packet = _packetManager.GetPackets();
            return View(packet);
        }
    }
}
