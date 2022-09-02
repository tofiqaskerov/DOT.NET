using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class RoleController : Controller
    {
        private readonly IRoleManager _roleManager;

        public RoleController(IRoleManager roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var role = _roleManager.GetAll();
            return View(role);

        }

      
        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var roleCount = _roleManager.GetAll().Count();
            if (roleCount >= 6) return RedirectToAction("Index");
            return View();
        }

    
        [HttpPost]
        public IActionResult Create(Roles role)
        {
            try
            {
                _roleManager.Add(role);
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
            var role = _roleManager.Get(id);
            if (role == null) return RedirectToAction("Index");
            return View(role);
        }


        [HttpPost]
        public IActionResult Edit(Roles role)
        {
            try
            {
                _roleManager.Update(role);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var role = _roleManager.Get(id);
            if(role == null) return NotFound();
            return View();
        }


        [HttpPost]
        public IActionResult Delete(Roles role)
        {
            try
            {
                _roleManager.Remove(role);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
