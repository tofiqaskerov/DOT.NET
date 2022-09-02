using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class PacketController : Controller
    {
        private readonly IPacketManager _packetManager;
        private readonly IPacketCategoryManager _packetCategoryManager;
        public PacketController(IPacketManager packetManager, IPacketCategoryManager packetCategoryManager)
        {
            _packetManager = packetManager;
            _packetCategoryManager = packetCategoryManager;
        }

        public IActionResult Index()
        {
            var packets = _packetManager.GetPackets();
            ViewBag.PacketLimit = packets.Count();
            return View(packets);
        }


        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            var packet = _packetManager.GetPackets();
            if (packet.Count() >2) return RedirectToAction("Index");
            var packetCategory = _packetCategoryManager.GetAll();
            ViewBag.PacketCategory = packetCategory;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Packet packet)
        {
            try
            {
                _packetManager.Add(packet);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public IActionResult Edit(int id)
        {
            var packet = _packetManager.GetByCategory(id);
            if(packet == null) return RedirectToAction("Index");
            var packetCategory = _packetCategoryManager.GetAll();
            ViewBag.PacketCategory = packetCategory; 
            return View(packet);
        }


        [HttpPost]
        public IActionResult Edit(Packet packet)
        {
            try
            {
                _packetManager.Update(packet);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var packet = _packetManager.Get(id);
            if (packet == null) return NotFound();
            return View();
        }


        [HttpPost]
        public IActionResult Delete(Packet packet)
        {
            try
            {
                _packetManager.Remove(packet);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
