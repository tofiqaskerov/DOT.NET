using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class PacketCategoryController : Controller
    {
        private readonly IPacketCategoryManager _packetCategoryManager;

        public PacketCategoryController(IPacketCategoryManager packetCategoryManager)
        {
            _packetCategoryManager = packetCategoryManager;
        }

        public IActionResult Index()
        {
            var packetCategory = _packetCategoryManager.GetAll();
            ViewBag.PacketCategoryLimit = packetCategory.Count();
            return View(packetCategory);
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var packetCategory = _packetCategoryManager.GetAll().Count();
            if (packetCategory > 4) return RedirectToAction("Index");
            return View();
        }

 
        [HttpPost]
        public IActionResult Create(PacketCategory packetCategory)
        {
            try
            {
                _packetCategoryManager.Add(packetCategory);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var packetCategory = _packetCategoryManager.Get(id);
            if (packetCategory == null) return RedirectToAction(nameof(Index));
            return View(packetCategory);
        }

 
        [HttpPost]
        public IActionResult Edit(PacketCategory packetCategory)
        {
            try
            {
                _packetCategoryManager.Update(packetCategory);
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
            var packetCategory = _packetCategoryManager.Get(id);
            if (packetCategory == null) return NotFound();
            return View();
            
        }

        [HttpPost]
        public IActionResult Delete(PacketCategory packetCategory)
        {
            try
            {
                _packetCategoryManager.Remove(packetCategory);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
